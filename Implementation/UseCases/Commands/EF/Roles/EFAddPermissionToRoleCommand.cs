﻿using Application.Exeptions;
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
    public class EFAddPermissionToRoleCommand : EFUseCase, IAddPermissionToRole
    {
        public EFAddPermissionToRoleCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 35;

        public string Name => "Add permission to role";

        public string Description => "Add permission to role using EF";

        public void Execute(RolePermission request)
        {
            var permission = Context.Permissions.Find(request.PermissionId);

            if(permission == null)
            {
                throw new NotFoundException("PErmission", request.PermissionId);
            }

            var role = Context.Roles.Find(request.RoleId);

            if(role == null)
            {
                throw new NotFoundException("Role", request.RoleId);
            }

            Context.RolesPermissions.Add(new Domain.Entities.RolePermission
            {
                Role = role,
                Permission = permission
            });

            Context.SaveChanges();

        }
    }
}