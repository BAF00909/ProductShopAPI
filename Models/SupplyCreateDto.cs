using ProductShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class SupplyCreateDto
    {
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public int EmployeeId { get; set; }
    }
}
