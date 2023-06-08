using Application.UseCases.Commands;
using Application.UseCases.Commands.Roles;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Roles
{
    public class EFUpdateRoleCommand : EFUseCase, IUpdateRoleCommand
    {
        private readonly UpdateRoleValidator _validator;

        public EFUpdateRoleCommand(BlogContext context, UpdateRoleValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Update role ";

        public string Description => "Update role ";

        public void Execute(UpdateEntityDto request)
        {
            _validator.ValidateAndThrow(request);

            var tag = Context.Tags.Find(request.Id);

            tag.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
