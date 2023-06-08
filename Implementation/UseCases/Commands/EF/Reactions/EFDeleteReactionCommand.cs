using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Reaction;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Reactions
{
    public class EFDeleteReactionCommand : EFUseCase, IDeleteReactionCommand
    {
        public EFDeleteReactionCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 28;

        public string Name => "Delete Reaction";

        public string Description => "Delete Reaction using EF";

        public void Execute(int request)
        {
            var reaction = Context.Reactions.Where(x => x.Id == request).FirstOrDefault();

            if (reaction == null)
            {
                throw new NotFoundException("Reaction", request);
            }

            if (reaction.Active == false)
            {
                throw new NotFoundException("Reaction", request);
            }

            reaction.Active = false;
            Context.SaveChanges();
        }
    }
}
