using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName {  get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public DateOnly StartDate { get; set; } = new DateOnly();
        public DateOnly? FinishDate { get; set;}
        [ForeignKey("PositionId")]
        public Position Position { get; set; } = null!;
        [Required]
        public int PositionId { get; set; }
    }
}
