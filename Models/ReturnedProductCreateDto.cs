using ProductShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class ReturnedProductCreateDto
    {
        public DateTime Date { get; set; } = new DateTime();
        public int SoltProductId { get; set; }
        public int ReasonReturnId { get; set; }
        public int EmployeeGetterId { get; set; }
    }
}
