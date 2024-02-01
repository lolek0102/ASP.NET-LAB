using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_3_8.Models
{
    public enum Manufacturer
    {
        [Display(Name = "Tesco")]
        Tesco,

        [Display(Name = "Aldi")]
        Aldi,

        [Display(Name = "Lidl")]
        Lidl,

        [Display(Name = "Auchan")]
        Auchan
    }

    public class Product
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu!")]
        [Display(Name = "Nazwa produktu")]
        public string Name { get; set; }

        [Range(0.01, 1000000.00, ErrorMessage = "Proszę podać cenę w zakresie od 0.01 do 1000000.00")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Proszę podać producenta!")]
        [Display(Name = "Producent")]
        public string Manufacturer { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data produkcji")]
        public DateTime ProductionDate { get; set; }

        [StringLength(1000, ErrorMessage = "Opis nie może przekraczać 1000 znaków.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int ShippingCarrierId { get; set; }
        public ShippingCarrier ShippingCarrier { get; set; }
    }
}
