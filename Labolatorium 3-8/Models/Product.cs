using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Labolatorium_3_8.Models
{
    public class Product
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu!")]
        public string Name { get; set; }

        [Range(0.01, 1000000.00, ErrorMessage = "Proszę podać cenę w zakresie od 0.01 do 1000000.00")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Proszę podać producenta!")]
        public string Manufacturer { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [StringLength(1000, ErrorMessage = "Opis nie może przekraczać 1000 znaków.")]
        public string Description { get; set; }
    }
}