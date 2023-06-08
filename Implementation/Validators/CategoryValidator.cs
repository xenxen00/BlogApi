using Application.UseCases.DTO;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CategoryValidator : AbstractValidator<CreateEntityDto>
    {
        public CategoryValidator(BlogContext context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Name is required.")
                    .Must(x => !context.Categories.Any(y => y.Name == x))
                    .WithMessage("Category with name {PropertyValue} already exists");
        }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateEntityDto>
    {
        public UpdateCategoryValidator(BlogContext context)
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Invalid entity identificator.")
                    .Must(x => context.Categories.Any(y => y.Id == x))
                    .WithMessage("Category with id {PropertyValue} doesn't exist");

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Name is required.");

        }
    }
}
