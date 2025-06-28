using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Dtos.Product
{
    public class ColorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }
        public Guid? ProductId { get; set; }
    }
}