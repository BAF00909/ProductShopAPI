using ProductShop.Entities;

namespace ProductShop.Models
{
    public class SoltProductUpdateDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
    }
}
