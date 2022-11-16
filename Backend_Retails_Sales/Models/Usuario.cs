using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Backend_Retails_Sales.Models
{
    public class Usuario
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string ID_INTERNO_ACCION { get; set; }
    }
}
