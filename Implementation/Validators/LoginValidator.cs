using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class LoginValidator : AbstractValidator<LoginCredentialsDto>
    {
        public LoginValidator(BlogContext context)
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required")
                .MinimumLength(5).WithMessage("Minimal length for Email is 5")
                .MaximumLength(30).WithMessage("Max length for Email is 30")
                .Must(x => context.Users.Any(y => y.Email == x)).WithMessage("There is not an account connected to this email: {PropertyValue} ");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Lozinka je obavezan podatak.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Minimal password length is of 8 characters, it must contain one capital letter, one lowercase letter, a number and a special character.");

        }
    }
}
