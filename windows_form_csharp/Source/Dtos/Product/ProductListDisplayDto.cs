using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Source.Dtos.Product
{
    public class ProductListDisplayDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public System.Drawing.Image Image { get; set; } // Image URL
        [Required]
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        //public string Status { get; set; }

    }
}
