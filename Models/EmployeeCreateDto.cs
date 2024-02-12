namespace ProductShop.Models
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public DateOnly StartDate { get; set; }
        public int PositionId { get; set; }
    }
}
