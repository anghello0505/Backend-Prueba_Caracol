using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
