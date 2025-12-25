using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineUrunYonetimi.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public string Name { get; set; } // Ürün adı

        [Required]
        public decimal Price { get; set; } // Fiyat

        public string Description { get; set; } // Açıklama

        public DateTime CreatedDate { get; set; } // Eklenme tarihi
    }
}
