using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Order
{
    public class OrderDetailsDisplayDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } 
        public int Quantity { get; set; } // Quantity of product
        public decimal UnitPrice { get; set; } // Price per unit
    }
}
