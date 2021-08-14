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
    public class ProductosController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public ActionResult<List<ProductoDTO>> Get()
        {
            var productos =  context.Productos.Where(x => x.Existencia > 0 );
            var dtos = mapper.Map<List<ProductoDTO>>(productos);

            return dtos;

        }

        [HttpGet("productos")]
        public async  Task<ActionResult<List<ProductoDTO>>> GetProductos()
        {
            var productos = await context.Productos.ToListAsync();
            var dtos = mapper.Map<List<ProductoDTO>>(productos);

            return dtos;

        }

        [HttpGet("{id}", Name = "ObtenerProducto")]
        public async Task<ActionResult<ProductoDTO>> Get(int id)
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);

            if (producto == null)
            {
                return NotFound($"No se encontro un producto con el id: {id}");
            }

            var dto = mapper.Map<ProductoDTO>(producto);

            return dto;

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoCreacionDTO producto)
        {
            var entidad = mapper.Map<Producto>(producto);

            var existe = await context.Productos.FirstOrDefaultAsync(x => x.Nombre == entidad.Nombre);
            if (existe != null)
            {
                return BadRequest($"Ya existe un producto con el nombre de: {existe.Nombre}");
            }
            context.Add(entidad);
            await context.SaveChangesAsync();
            var productoDTO = mapper.Map<ProductoDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerProducto", new { id = productoDTO.IdProducto }, productoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoCreacionDTO productoCreacionDTO)
        {
            var entidad = mapper.Map<Producto>(productoCreacionDTO);
            entidad.IdProducto = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerProducto", new { id = entidad.IdProducto }, entidad);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.IdProducto == id);

            if (!existe)
            {
                return NotFound("No se encontro ningun Producto con ese Nombre");
            }

            context.Remove(new Producto() { IdProducto = id });
            await context.SaveChangesAsync();

            return NoContent();
        }


    }
}
