using ProductShop.Entities;

namespace ProductShop.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get => $"{LastName} {FirstName} {SecondName}";
            set => FullName = value;
        }
        public DateOnly Birthday { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinishDate { get; set; }
        public Position Position { get; set; }
    }
}
