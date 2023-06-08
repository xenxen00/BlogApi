using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PermissionDto> Permissions { get; set; } = Enumerable.Empty<PermissionDto>();
    }

    public class PermissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
