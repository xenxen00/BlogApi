using Application.Exeptions;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Users
{
    public class EFDeleteUserCommand : EFUseCase, IDeleteUserCommand
    {
        public EFDeleteUserCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 39;

        public string Name => "";

        public string Description => "";

        public void Execute(int request)
        {
            var user = Context.Users.Where(x => x.Id == request).FirstOrDefault();

            if (user == null)
            {
                throw new NotFoundException("User", request);
            }

            if (user.Active == false)
            {
                throw new NotFoundException("User", request);
            }

            user.Active = false;
            Context.SaveChanges();
        }
    }
}
