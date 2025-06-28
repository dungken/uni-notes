using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
