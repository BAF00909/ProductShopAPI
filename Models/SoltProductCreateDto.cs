using ProductShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class SoltProductCreateDto
    {
        public DateTime Date { get; set; } = new DateTime();
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
    }
}
