using Prueba_Tecnica.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.DTOs
{
    public class VendedorCreacionDTO
    {
        
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        [Required]
        [VerificacionGenero]
        public string Genero { get; set; }
        [Required]
        public string Telefono { get; set; }
    }
}
