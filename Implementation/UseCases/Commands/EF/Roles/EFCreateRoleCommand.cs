using Application.UseCases.Commands.Roles;
using Application.UseCases.DTO;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Role
{
    public class EFCreateRoleCommand : EFUseCase, ICreateRoleCommand
    {
        private readonly RoleValidator _validator;
        public EFCreateRoleCommand(BlogContext context, RoleValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Create role";

        public string Description => "Create role using EF";

        public void Execute(CreateEntityDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.Add(new Category
            {
                Name = request.Name,
            });

            Context.SaveChanges();
        }
    }
}
