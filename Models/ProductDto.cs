﻿using ProductShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int Art { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public DateTime DateIn { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
        public ProductGroup ProductGroup { get; set; } = null!;
        public Supply Supply { get; set; } = null!;
    }
}
