using Prueba_Tecnica.Entidades;
using Prueba_Tecnica.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.DTOs
{
    public class PedidoDTO
    {
        [Key]
        public int IdPedido { get; set; }
        [Required]
        public int IdVendedor { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime FechaEmision { get; set; }
        [Required]
        [verificarEstado]
        public string Estado { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public int IdVendedorAprobado { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
