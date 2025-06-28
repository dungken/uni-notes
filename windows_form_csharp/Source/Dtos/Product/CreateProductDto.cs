using Source.Dtos.Product;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Product
{
    public class CreateProductDto
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

        public List<ColorDTO> Colors { get; set; } = new List<ColorDTO>();
        public List<SizeDTO> Sizes { get; set; } = new List<SizeDTO>();
        public List<ImageDTO> Images { get; set; } = new List<ImageDTO>();
        public List<FeedbackDTO> Feedbacks { get; set; } = new List<FeedbackDTO>();
    }
}
