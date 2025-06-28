using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Reponse
{
    public class GetUserByTokenRespone
    {
        public Source.Models.User User { get; set; }
        public IList<string> Roles { get; set; }
        public IList<string> Permissions { get; set; }
    }
}
