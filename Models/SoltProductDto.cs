using ProductShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class SoltProductDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public Product Product { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}
