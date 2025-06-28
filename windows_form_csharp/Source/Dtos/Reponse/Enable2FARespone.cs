using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Reponse
{
    public class Enable2FARespone
    {
        public bool TwoFactorEnabled { get; set; }
        public string VerificationCode { get; set; }
    }
}
