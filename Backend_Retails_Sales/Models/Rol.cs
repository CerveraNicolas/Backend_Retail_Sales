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
        public int IdRol { get; set; }

        [MaxLength(200)]
        public string? Descripcion { get; set; }

        public bool EsActivo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }    
    }
}
