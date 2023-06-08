using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Permissions;
using Application.UseCases.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Permissions
{
    public class EFDeletePermissionCommand : EFUseCase, IDeletePermissionCommand
    {
        public EFDeletePermissionCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Delete permission";

        public string Description => "Delete permission using EF";

        public void Execute(int request)
        {
            var permission = Context.Permissions.Where(x => x.Id == request).FirstOrDefault();

            if (permission == null)
            {
                throw new NotFoundException("Permission", request);
            }

            permission.Active = false;
            Context.SaveChanges();
        }
    }
}
