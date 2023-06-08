using Application.Exeptions;
using Application.UseCases.Commands.Roles;
using Application.UseCases.DTO;
using DataAccess;

namespace Implementation.UseCases.Commands.EF.Roles
{
    public class EFDeleteRoleCommand : EFUseCase, IDeleteRoleCommand
    {
        public EFDeleteRoleCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Delete role";

        public string Description => "Delete role using EF";

        public void Execute(int request)
        {
            var role = Context.Roles.Where(x => x.Id == request).FirstOrDefault();

            if (role == null)
            {
                throw new NotFoundException("Role", request);
            }

            role.Active = false;
            Context.SaveChanges();
        }
    }
}
