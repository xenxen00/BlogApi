using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class PermissionValidator : AbstractValidator<CreatePermissionDto>
    {
        public PermissionValidator(BlogContext context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name property is required")
                .Must(x => !context.Permissions.Any(y => y.Name == x)).WithMessage("Permission with ${PropertyValue}for name value already exists");
            
            RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Description property is required")
                .Must(x => !context.Permissions.Any(y => y.Description == x)).WithMessage("Permission with ${PropertyValue}for name value already exists");
        }
    }

    public class UpdatePermissionValidator : AbstractValidator<UpdatePermissionDto>
    {
        public UpdatePermissionValidator(BlogContext context)
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Invalid entity identificator.")
                    .Must(x => context.Permissions.Any(y => y.Id == x))
                    .WithMessage("Permission with id {PropertyValue} doesn't exist");

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Name is required.")
                    .Must(x => !context.Permissions.Any(y => y.Name == x))
                    .WithMessage("Permission with Name {PropertyValue} already exists");

            RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Description is required.");

        }
    }
}
