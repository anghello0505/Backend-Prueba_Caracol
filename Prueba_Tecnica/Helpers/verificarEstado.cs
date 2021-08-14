using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Helpers
{
    public class verificarEstado:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var generoVerificar = value.ToString();

            if (generoVerificar == "Registrado" || generoVerificar == "Aprobado")
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Los estados aceptados son Registrado y/o Aprobado");
        }

    }
}
