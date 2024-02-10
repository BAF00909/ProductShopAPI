using ProductShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class OverdueProductCreateDto
    {
        public DateTime CreateDate { get; set; } = new DateTime();
        public int ProductOverdueId { get; set; }
        public int EmployeeDecommisionId { get; set; }
    }
}
