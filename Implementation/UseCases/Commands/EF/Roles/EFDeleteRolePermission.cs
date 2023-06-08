using Application.Exeptions;
using Application.UseCases.Commands.Roles;
using Application.UseCases.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Roles
{
    public class EFDeleteRolePermission : EFUseCase, IDeleteRolePermission
    {
        public EFDeleteRolePermission(BlogContext context) : base(context)
        {
        }

        public int Id => 36;

        public string Name => "Delete role permission";

        public string Description => "Delete role permission using EF";

        public void Execute(RolePermissionDto request)
        {
            var rolePermission = Context.RolesPermissions
                .Where(x => x.RoleId == request.RoleId && x.PermissionId == request.PermissionId)
                .FirstOrDefault();

            if (rolePermission == null)
            {
                throw new NotFoundException("RolePermission", request.PermissionId);
            }

            Context.RolesPermissions.Remove(rolePermission);
            Context.SaveChanges();
        }
    }
}
