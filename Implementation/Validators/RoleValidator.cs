using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class RoleValidator : AbstractValidator<CreateEntityDto>
    {
        public RoleValidator(BlogContext context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .Must(x => !context.Categories.Any(y => y.Name == x))
                .WithMessage("Category with name {PropertyValue} already exists");
        }

        
    }

    public class UpdateRoleValidator : AbstractValidator<UpdateEntityDto>
    {
        public UpdateRoleValidator(BlogContext context)
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Invalid entity identificator.")
                    .Must(x => context.Roles.Any(y => y.Id == x))
                    .WithMessage("Role with id {PropertyValue} doesn't exist");

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Name is required.");

        }
    }
}
