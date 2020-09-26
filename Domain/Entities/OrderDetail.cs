namespace Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
