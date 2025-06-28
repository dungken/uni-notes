using System.ComponentModel.DataAnnotations;
using Source.Dtos.Product;

namespace api.Dtos.Product
{
    public class UpdateProductDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }

        public string Status { get; set; }
        public Guid? DiscountId { get; set; }
        public byte[]? RowVersion { get; set; }
    }
}
