using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.DTOs
{
    public class ProductoDTO
    {
        [Key]
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Range(0, 1000)]
        public int Existencia { get; set; }
        [Required]
        public string Provedor { get; set; }
    }
}
