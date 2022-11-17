using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Retails_Sales.Models
{
    /**
     * Modelo Clase Venta
     * Representa la tabla para contener nuevas ventas en la base de datos.
     */
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string DNI { get; set; }

        [Required]
        [MaxLength(200)]
        public string TipoPago { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public float Total { get; set; }
    }
}
