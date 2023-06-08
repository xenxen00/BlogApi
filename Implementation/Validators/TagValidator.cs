using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class TagValidator: AbstractValidator<CreateEntityDto>
    {
        public TagValidator(BlogContext context) {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Name is required.")
                    .Must(x => !context.Tags.Any(y => y.Name == x))
                    .WithMessage("Tag with name {PropertyValue} already exists");

        }
    }

    public class UpdateTagValidator : AbstractValidator<UpdateEntityDto>
    {
        public UpdateTagValidator(BlogContext context)
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Invalid entity identificator.")
                    .Must(x => context.Tags.Any(y => y.Id == x))
                    .WithMessage("Tag with id {PropertyValue} doesn't exist");

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Name is required.");

        }
    }
}
