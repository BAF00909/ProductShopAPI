using ProductShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class ProductCreateDto
    {
        public int Art { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public DateTime DateIn { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
        public int ProductGroupId { get; set; }
        public int SupplyId { get; set; }
    }
}
