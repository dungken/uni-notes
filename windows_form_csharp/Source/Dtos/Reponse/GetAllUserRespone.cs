using Source.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Reponse
{
    public class GetAllUserRespone
    {
        public int TotalUser { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<UserForResponeDto> Users { get; set; }

    }
}
