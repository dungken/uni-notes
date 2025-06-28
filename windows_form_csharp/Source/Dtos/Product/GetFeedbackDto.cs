using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Product
{
    public class GetFeedbackDto
    {
        public string UserFullName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
