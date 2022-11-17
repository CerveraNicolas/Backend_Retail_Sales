using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Backend_Retails_Sales.Models
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Descripcion { get; set; }

        [Required]
        public bool Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }    
    }
}
