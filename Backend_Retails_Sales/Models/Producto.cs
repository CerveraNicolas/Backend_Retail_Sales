﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace Backend_Retails_Sales.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Alias { get; set; }

        [MaxLength(200)]
        [Required]
        public int Stock { get; set; }

        [MaxLength(200)]
        [Required]
        public decimal Precio { get; set; }

        [MaxLength(200)]
        [Required]
        public bool EsActivo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HoraRegistro { get; set; }
    }
}
