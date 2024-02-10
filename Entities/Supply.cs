using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Entities
{
    public class Supply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("ProviderId")]
        public Provider? Provider { get; set; }
        public int ProviderId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? EmployeeAccepted { get; set; }
        public int EmployeeId { get; set; }
    }
}
