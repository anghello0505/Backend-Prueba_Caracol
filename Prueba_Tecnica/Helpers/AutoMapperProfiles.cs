using AutoMapper;
using Prueba_Tecnica.DTOs;
using Prueba_Tecnica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<ClienteCreacionDTO, Cliente>();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<ProductoCreacionDTO, Producto>();
            CreateMap<Vendedor, VendedorDTO>().ReverseMap();
            CreateMap<VendedorCreacionDTO, Vendedor>();
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<PedidoCreacionDTO, Pedido>();
        }
    }
}
