using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class CartItem
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key
        public Guid CartId { get; set; } 
        public Cart Cart { get; set; } 
        public Guid ProductId { get; set; } 
        public ProductDTO Product { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; } 
        public decimal UnitPrice { get; set; } 

    }
}
