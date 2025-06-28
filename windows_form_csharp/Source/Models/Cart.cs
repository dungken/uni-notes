using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class Cart
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key
        public Guid UserId { get; set; } // user has the cart
        public User User { get; set; } // Navigation property
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>(); // List product in the cart
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Timestamp] // This attribute marks the property for concurrency tracking
        public byte[] RowVersion { get; set; }

        public decimal TotalPrice;
    }
}
