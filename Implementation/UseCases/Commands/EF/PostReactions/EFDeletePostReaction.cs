using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.PostReactions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.PostReactions
{
    public class EFDeletePostReaction : EFUseCase, IDeletePostReactionCommand
    {
        public EFDeletePostReaction(BlogContext context) : base(context)
        {
        }

        public int Id => 38;

        public string Name => "Delete post reaction (EF)";

        public string Description => "Delete post reaction using EntityFramework";

        public void Execute(int request)
        {
            var postReaction = Context.PostReactions.Find(request);

            if(postReaction == null) 
            {
                throw new NotFoundException("PostReaction", request);
            }

            Context.PostReactions.Remove(postReaction);
            Context.SaveChanges();
        }
    }
}
