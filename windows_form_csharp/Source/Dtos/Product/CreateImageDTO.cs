using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Product
{
    public class CreateImageDTO
    {
        public Guid? Id { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
