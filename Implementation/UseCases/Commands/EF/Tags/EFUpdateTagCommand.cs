using Application.UseCases.Commands;
using Application.UseCases.Commands.Tag;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Tags
{
    public class EFUpdateTagCommand : EFUseCase, IUpdateTagCommand
    {
        private readonly UpdateTagValidator _validator;

        public EFUpdateTagCommand(BlogContext context, UpdateTagValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "";

        public string Description => "";

        public void Execute(UpdateEntityDto request)
        {
            _validator.ValidateAndThrow(request);

            var tag = Context.Tags.Find(request.Id);

            tag.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
