namespace ProductShop.Models
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime StartDate { get; set; }
        public int PositionId { get; set; }
    }
}
