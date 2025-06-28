using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Product
{
    public class ProductDisplayDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string ColorName { get; set; }
    }
}
