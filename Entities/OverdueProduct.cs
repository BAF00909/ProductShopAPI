using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Entities
{
    public class OverdueProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = new DateTime();
        [ForeignKey("ProductOverdueId")]
        public Product Product { get; set; } = null!;
        public int ProductOverdueId { get; set; }
        [ForeignKey("EmployeeDecommisionId")]
        public Employee Employee { get; set; } = null!;
        public int EmployeeDecommisionId { get; set; }
    }
}
