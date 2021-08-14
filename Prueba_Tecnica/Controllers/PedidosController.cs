using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Context;
using Prueba_Tecnica.DTOs;
using Prueba_Tecnica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PedidosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> Get()
        {
            var pedidos = await context.Pedidos.Include("Vendedor").Include("Cliente").Include("Producto").ToListAsync();
            var dtos = mapper.Map<List<PedidoDTO>>(pedidos);

            return dtos;

        }

        [HttpGet("/registrados")]
        public ActionResult<List<PedidoDTO>> GetRegistrados()
        {
            var pedidosRegistrados =  context.Pedidos.Where(x => x.Estado == "Registrado").ToList();
            var dtos = mapper.Map<List<PedidoDTO>>(pedidosRegistrados);

            return dtos;
        }

        [HttpGet("/aprobados")]
        public ActionResult<List<PedidoDTO>> GetAprobados()
        {
            var pedidosRegistrados = context.Pedidos.Where(x => x.Estado == "Aprobado").ToList();
            var dtos = mapper.Map<List<PedidoDTO>>(pedidosRegistrados);

            return dtos;
        }



        [HttpGet("{id}", Name = "ObtenerPedido")]
        public async Task<ActionResult<PedidoDTO>> Get(int id)
        {
            var pedido = await context.Pedidos.Include("Vendedor").Include("Cliente").Include("Producto").FirstOrDefaultAsync(x => x.IdPedido == id);

            if (pedido == null)
            {
                return NotFound($"No se encontro ningun pedido con el id: {id}");
            }

            var dto = mapper.Map<PedidoDTO>(pedido);

            return dto;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PedidoCreacionDTO pedido)
        {
            var entidad = mapper.Map<Pedido>(pedido);
            context.Add(entidad);

            var producto = await context.Productos.FirstOrDefaultAsync(x => x.IdProducto == entidad.IdProducto);
            if (producto.Existencia < entidad.Cantidad)
            {
                return BadRequest("La demanda del Producto es mayor a la cantidad en Existencia");
            }
            else
            {
                producto.Existencia = producto.Existencia - entidad.Cantidad;
                context.Entry(producto).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            var pedidoDTO = mapper.Map<PedidoDTO>(entidad);
            return new CreatedAtRouteResult("ObtenerPedido", new { id = pedidoDTO.IdPedido }, pedidoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PedidoCreacionDTO pedidoCreacionDTO)
        {
            var entidad = mapper.Map<Pedido>(pedidoCreacionDTO);
            entidad.IdPedido = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerProducto", new { id = entidad.IdPedido }, entidad);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Pedidos.AnyAsync(x => x.IdPedido == id);

            if (!existe)
            {
                return NotFound("No se encontro ningun Pedido con ese Id");
            }

            context.Remove(new Pedido() { IdPedido = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
