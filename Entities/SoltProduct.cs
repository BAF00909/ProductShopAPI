using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Entities
{
    public class SoltProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } = null!;
        public int EmployeeId { get; set; }
    }
}
