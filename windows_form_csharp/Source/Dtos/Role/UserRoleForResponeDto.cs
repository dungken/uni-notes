using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Role
{
    public class UserRoleForResponeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<RolePermissionDto> Permissions { get; set; }
    }
}
