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
    public class RegistrationValidator : AbstractValidator<CreateUserDto>
    {
        public RegistrationValidator(BlogContext context)
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required")
                .MinimumLength(5).WithMessage("Minimal length for Email is 5")
                .MaximumLength(30).WithMessage("Max length for Email is 30")
                .Must(x => !context.Users.Any(y => y.Email == x)).WithMessage("{PropertyValue} is already being used");

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required")
                .Matches(@"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$").WithMessage("First name is invalid");

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required")
                .Matches(@"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$").WithMessage("Last name is invalid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Lozinka je obavezan podatak.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Minimal password length is of 8 characters, it must contain one capital letter, one lowercase letter, a number and a special character.");

        }
    }
}
