using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Product
{
    public class GetAllSizeRespone
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid? ProductId { get; set; }
    }
}
