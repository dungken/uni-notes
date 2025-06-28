using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Reponse
{
    public class GetPersonalInformationRespone
    {
        Source.Models.User User { get; set; }
        List<Guid> Roles { get; set; }
        List<Guid> Permissions { get; set; }
    }
}
