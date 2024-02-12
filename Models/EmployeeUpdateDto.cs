using ProductShop.Entities;

namespace ProductShop.Models
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinishDate { get; set; }
        public int PositionId { get; set; }
    }
}
