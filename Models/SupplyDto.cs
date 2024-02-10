using ProductShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class SupplyDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Provider Provider { get; set; } = null!;
        public Employee EmployeeAccepted { get; set; } = null!;
    }
}
