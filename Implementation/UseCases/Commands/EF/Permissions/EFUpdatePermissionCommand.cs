using Application.UseCases.Commands.Permissions;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Permissions
{
    public class EFUpdatePermissionCommand : EFUseCase, IUpdatePermissionCommand
    {
        private readonly UpdatePermissionValidator _validator;
        public EFUpdatePermissionCommand(BlogContext context, UpdatePermissionValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Update permission";

        public string Description => "Update permission using EF";

        public void Execute(UpdatePermissionDto request)
        {
            _validator.ValidateAndThrow(request);

            var perm = Context.Permissions.Find(request.Id);
            perm.Name = request.Name;
            perm.Description = request.Description;

            Context.SaveChanges();
        }
    }
}
