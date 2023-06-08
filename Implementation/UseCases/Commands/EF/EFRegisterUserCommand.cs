using Application.UseCases.Commands;
using Application.UseCases.DTO;
using BCrypt.Net;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.EF
{
    public class EFRegisterUserCommand : EFUseCase, IRegisterUserCommand
    {
        private readonly RegistrationValidator _validator;
        public int Id => 1;
        public string Name => "Registration of user (EF)";
        public string Description => "Registration of user using Entity Framework";

        public EFRegisterUserCommand(BlogContext context, RegistrationValidator validator) : base(context)
        {
            _validator = validator;
        }

        public void Execute(CreateUserDto request)
        {
            _validator.ValidateAndThrow(request);

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var defaultRole = Context.Roles.Where(x => x.Name == "User").FirstOrDefault();

            var user = new User
            {
                Email = request.Email,
                Password = passwordHash,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            if(defaultRole != null)
            {
                user.Role = defaultRole;
            }

            Context.Add(user);
            Context.SaveChanges();

        }
    }
}
