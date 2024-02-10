using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Art { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public DateTime DateIn { get; set; }
        public int Count { get; set; }
        public decimal Cost {  get; set; }
        [ForeignKey("ProductGroupId")]
        public ProductGroup ProductGroup { get; set; } = null!;
        public int ProductGroupId { get; set; }
        [ForeignKey("SupplyId")]
        public Supply Supply { get; set; } = null!;
        public int SupplyId { get; set; }
    }
}
