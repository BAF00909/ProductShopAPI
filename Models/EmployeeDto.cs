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
        public DateTime Birthday { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Position Position { get; set; }
    }
}
