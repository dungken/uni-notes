using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Reponse
{
    public class CreatePaymentRespone<T>
    {
        public string ActionName { get; set; }     
        public Guid OrderId { get; set; }     
        public T Data { get; set; }
    }
}
