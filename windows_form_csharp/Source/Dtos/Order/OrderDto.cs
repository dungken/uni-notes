using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Source.Dtos.Payment;

namespace Source.Dtos.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string shippingAddress { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public PaymentDto Payment { get; set; }
        public Guid? VoucherID { get; set; }
    }
}