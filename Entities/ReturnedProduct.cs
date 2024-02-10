using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Entities
{
    public class ReturnedProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        [ForeignKey("SoltProductId")]
        public SoltProduct SoltProduct { get; set; } = null!;
        public int SoltProductId {  get; set; }
        [ForeignKey("ReasonReturnId")]
        public ReasonReturn ReasonReturn { get; set; } = null!;
        public int ReasonReturnId { get; set;}
        [ForeignKey("EmployeeGetterId")]
        public Employee Employee { get; set; } = null!;
        public int EmployeeGetterId { get; set; }
    }
}
