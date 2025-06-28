using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Dtos.Order
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }   
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Total { get; set; }
    }
}