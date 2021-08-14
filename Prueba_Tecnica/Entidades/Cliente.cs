using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Entidades
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int TelefonoContacto { get; set; }

    }
}
