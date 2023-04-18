using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCORE.Models
{
    public class ContactoModel
    {
        public int? IdContacto { get; set; }
        [Required(ErrorMessage = "Se requiere el Nombre del contacto")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$", ErrorMessage = "El nombre no puede tener numeros, solo letras")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Se requiere el Telefono del contacto")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "El telefono lleva 10 digitos numericos")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Se requiere el Correo del contacto")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "El correo no es valido, revisa que tenga el formato correcto !")]
        public string? Correo { get; set; }
    }

}
