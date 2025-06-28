using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Reponse
{
    public class SendCodeForForgetPasswordRespone
    {
        public string Email { get; set; }
        public Guid userId { get; set; }
        public string Token { get; set; }
        public string ResetToken { get; set; }
    }
}
