using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Reponse
{
    public class ForgotPasswordRespone
    {
        public string Email { get; set; }
        public string ResetLink { get; set; }
    }
}
