using ProductShop.Entities;

namespace ProductShop.Models
{
    public class ReturnedProductDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public SoltProduct SoltProduct { get; set; } = null!;
        public ReasonReturn ReasonReturn { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
        public int EmployeeGetterId { get; set; }
    }
}
