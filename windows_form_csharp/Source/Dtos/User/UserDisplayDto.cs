using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Models;

namespace Source.Dtos.User
{
    public class UserDisplayDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email {  get; set; }  
        public string Phone { get; set; }
        public decimal TotalOrders {  get; set; }    

    }
}
