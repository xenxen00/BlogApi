using Application.UseCases.Commands.Tag;
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

namespace Implementation.UseCases.Commands.EF.Tags
{
    public class EFCreateTagCommand : EFUseCase, ICreateTagCommand
    {
        private readonly TagValidator _validator;

        public EFCreateTagCommand(BlogContext context, TagValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "";

        public string Description => "";

        public void Execute(CreateEntityDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.Add(new Tag
            {
                Name = request.Name,
            });

            Context.SaveChanges();
        }
    }
}
