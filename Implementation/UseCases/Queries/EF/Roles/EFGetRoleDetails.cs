using Application.Exeptions;
using Application.UseCases.DTO;
using Application.UseCases.Queries.Roles;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.EF.Roles
{
    internal class EFGetRoleDetails : EFUseCase, IGetRoleDetails
    {
        public EFGetRoleDetails(BlogContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "";

        public string Description => "";

        public RoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
            {
                throw new NotFoundException("Role", request);
            }

            var data = new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Permissions = role.RolePermissions.Select(y => new PermissionDto
                {
                    Id = y.Permission.Id,
                    Name = y.Permission.Name,
                    Description = y.Permission.Description
                }).ToList()
            };

            return data;
            
        }
    }
}
