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
    public class ReactionValidator : AbstractValidator<CreateEntityDto>
    {
        public ReactionValidator(BlogContext context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Name is required.")
                    .Must(x => !context.Reactions.Any(y => y.Name == x))
                    .WithMessage("Reaction with name {PropertyValue} already exists");
        }
    }

    public class UpdateReactionValidator : AbstractValidator<UpdateEntityDto>
    {
        public UpdateReactionValidator(BlogContext context)
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Invalid entity identificator.")
                    .Must(x => context.Reactions.Any(y => y.Id == x))
                    .WithMessage("Reaction with id {PropertyValue} doesn't exist");

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Name is required.");

        }
    }
}
