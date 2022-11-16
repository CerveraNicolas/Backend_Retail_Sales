using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Backend_Retails_Sales.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(200)]
        [Required]
        public string Apellido { get; set; }

        [MaxLength(200)]
        public string Correo { get; set; }

        [MaxLength(100)]
        [Required]
        public string Contrasenia { get; set; }

        [Required]
        public bool EsActivo { get; set; }
    }
}
