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
        public DateTime Birthday { get; set; }
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime? FinishDate { get; set;}
        [ForeignKey("PositionId")]
        public Position Position { get; set; } = null!;
        [Required]
        public int PositionId { get; set; }
    }
}
