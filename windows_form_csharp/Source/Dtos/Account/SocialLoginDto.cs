using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Dtos.Account
{
    public class SocialLoginDto
    {
        public string AccessToken { get; set; }
        public string Provider { get; set; } // "Google" or "Facebook"
    }
}