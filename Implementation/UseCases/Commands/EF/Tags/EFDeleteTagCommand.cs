using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Tag;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Tags
{
    public class EFDeleteTagCommand : EFUseCase, IDeleteTagCommand
    {
        public EFDeleteTagCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "";

        public string Description => "";

        public void Execute(int request)
        {
            var tag = Context.Tags.Where(x => x.Id == request).FirstOrDefault();

            if (tag == null)
            {
                throw new NotFoundException("Tag", request);
            }

            tag.Active = false;
            Context.SaveChanges();
        }
    }
}
