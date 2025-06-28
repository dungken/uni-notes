using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Reponse
{
    public class GenerateSignatureRespone
    {
        public string Signature { get; set; }
        public string apiKey { get; set; }
        public string cloudName { get; set; }
    }
}
