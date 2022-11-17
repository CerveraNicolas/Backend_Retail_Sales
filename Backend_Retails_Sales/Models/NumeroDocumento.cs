using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Backend_Retails_Sales.Models
{
    [Table("NumeroDocumento")]
    public class NumeroDocumento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime? FechaRegistro { get; set; }
    }
}
