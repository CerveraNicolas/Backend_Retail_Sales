using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Backend_Retails_Sales.Models
{
    /**
     * Modelo Clase Categoria
     * Representa la categoría en la que se encuentra uno o varios productos.
     */
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public bool Activada { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }
    }
}
