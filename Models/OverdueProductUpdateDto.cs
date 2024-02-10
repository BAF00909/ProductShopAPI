namespace ProductShop.Models
{
    public class OverdueProductUpdateDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProductOverdueId { get; set; }
        public int EmployeeDecommisionId { get; set; }
    }
}
