using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Product
{
    public class GetOrderDetailDto
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
