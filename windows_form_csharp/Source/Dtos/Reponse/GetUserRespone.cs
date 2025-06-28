using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Models;
namespace Source.Dtos.Reponse
{
    public class GetUserRespone
    {
        public Source.Models.User user { get; set; }
        public IList<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
    }
}
