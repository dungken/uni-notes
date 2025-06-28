using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Dtos.Role
{
    public class CreateRoleDto
    {
        public string Name { get; set; }
        public List<Guid> Permissions { get; set; }
    }
}