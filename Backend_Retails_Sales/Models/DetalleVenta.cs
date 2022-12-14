using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Retails_Sales.Models
{
    /**
     * Modelo Clase DetalleVenta
     * Representa una nueva tabla en la base de datos con información sobre una venta en especifico.
     * La cantidad comprada, identificador del producto, total, etc.
     */
    [Table("DetalleVenta")]
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Venta VentaObject { get; set; }

        [Required]
        public Producto ProductObject { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public float Precio { get; set; }

        [Required]
        public float Total { get; set; }
    }
}
