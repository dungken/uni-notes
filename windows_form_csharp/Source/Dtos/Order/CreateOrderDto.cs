using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Dtos.Order
{
    public class CreateOrderDto
    {
        public Guid OrderId { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; } = new List<CreateOrderDetailDto>();
        public string Status { get; set; } = "pending";
        public string ShippingAddress { get; set; }
        public Guid UserId { get; set; }
    }
}