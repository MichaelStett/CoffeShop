using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderPlaced { get; set; }
        public decimal Price { get; set; }
    }
}
