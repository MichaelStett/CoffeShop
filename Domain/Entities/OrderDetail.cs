namespace Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitTimeToPrepare { get; set; }
        public string AdditionalInfo { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
