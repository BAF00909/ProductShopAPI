namespace ProductShop.Models
{
    public class SupplyUpdateDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public int EmployeeId { get; set; }
    }
}
