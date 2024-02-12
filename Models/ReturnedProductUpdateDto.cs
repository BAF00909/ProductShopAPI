namespace ProductShop.Models
{
    public class ReturnedProductUpdateDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public int SoltProductId { get; set; }
        public int ReasonReturnId { get; set; }
        public int EmployeeGetterId { get; set; }
    }
}
