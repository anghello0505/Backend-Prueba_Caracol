using Prueba_Tecnica.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Entidades
{
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }
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
