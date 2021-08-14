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
    public class VendedoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public VendedoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<VendedorDTO>>> Get()
        {
            var vendedores = await context.Vendedores.ToListAsync();
            var dtos = mapper.Map<List<VendedorDTO>>(vendedores);

            return dtos;

        }

       

        [HttpGet("{id}", Name = "ObtenerVendedor")]
        public async Task<ActionResult<VendedorDTO>> Get(int id)
        {
            var vendedor = await context.Vendedores.FirstOrDefaultAsync(x => x.IdVendedor == id);

            if (vendedor == null)
            {
                return NotFound($"No se encontro un vendedor con el id: {id}");
            }

            var dto = mapper.Map<VendedorDTO>(vendedor);

            return dto;

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VendedorCreacionDTO vendedor)
        {
            var entidad = mapper.Map<Vendedor>(vendedor);

            var existe = await context.Vendedores.FirstOrDefaultAsync(x => x.Nombre == entidad.Nombre);
            if (existe != null)
            {
                return BadRequest($"Ya existe un vendedor con el nombre de: {existe.Nombre}");
            }
            context.Add(entidad);
            await context.SaveChangesAsync();
            var vendedorDTO = mapper.Map<VendedorDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerVendedor", new { id = vendedorDTO.IdVendedor }, vendedorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] VendedorCreacionDTO vendedorCreacionDTO)
        {
            var entidad = mapper.Map<Vendedor>(vendedorCreacionDTO);
            entidad.IdVendedor = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerVendedor", new { id = entidad.IdVendedor }, entidad);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Vendedores.AnyAsync(x => x.IdVendedor == id);

            if (!existe)
            {
                return NotFound("No se encontro ningun Vendedor con ese Nombre");
            }

            context.Remove(new Vendedor() { IdVendedor = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
