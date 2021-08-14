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
    public class ClientesController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientesController(ApplicationDbContext context  ,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> Get()
        {
            var clientes = await context.Clientes.ToListAsync();
            var dtos = mapper.Map<List<ClienteDTO>>(clientes);

            return dtos;

        }

        [HttpGet("{id}", Name = "ObtenerCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);

            if (cliente == null)
            {
                return NotFound($"No se encontro un cliente con el id: {id}");
            }

            var dto = mapper.Map<ClienteDTO>(cliente);

            return dto;

        }
         [HttpPost]
         public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO cliente)
        {
            var entidad = mapper.Map<Cliente>(cliente);

            var existe = await context.Clientes.FirstOrDefaultAsync(x => x.TelefonoContacto == entidad.TelefonoContacto);
            if (existe != null)
            {
                return BadRequest($"Ese numero de Telefono ya esta registrado con el nombre de: {existe.Nombre}");
            }
            context.Add(entidad);
            await context.SaveChangesAsync();
            var clienteDTO = mapper.Map<ClienteDTO>(entidad);

            return new CreatedAtRouteResult("obtenerCliente", new { id = clienteDTO.IdCliente }, clienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteCreacionDTO clienteCreacionDTO)
        {
            var entidad = mapper.Map<Cliente>(clienteCreacionDTO);
            entidad.IdCliente = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerCliente", new { id = entidad.IdCliente }, entidad);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Clientes.AnyAsync(x => x.IdCliente == id);

            if (!existe)
            {
                return NotFound("No se encontro ningun Cliente con ese numero de Id");
            }

            context.Remove(new Cliente() { IdCliente = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
