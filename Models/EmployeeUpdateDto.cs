using ProductShop.Entities;

namespace ProductShop.Models
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int PositionId { get; set; }
    }
}
