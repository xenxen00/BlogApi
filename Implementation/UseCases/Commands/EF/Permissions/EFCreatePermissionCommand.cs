using Application.UseCases.Commands.Permissions;
using Application.UseCases.DTO;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.EF.Permissions
{
    public class EFCreatePermissionCommand : EFUseCase, ICreatePermissionCommand
    {
        private readonly PermissionValidator _permissionValidator;
        public EFCreatePermissionCommand(BlogContext context, PermissionValidator permissionValidator) : base(context)
        {
            _permissionValidator = permissionValidator;
        }

        public int Id => 18;

        public string Name => "Creates new permission (EF)";

        public string Description => "Creates a new permission using Entity Framework.";

        public void Execute(CreatePermissionDto request)
        {
            _permissionValidator.ValidateAndThrow(request);
            
            Context.Permissions.Add(new Permission
            {
                Name = request.Name,
                Description = request.Description
            });

            Context.SaveChanges();
        }
    }
}
