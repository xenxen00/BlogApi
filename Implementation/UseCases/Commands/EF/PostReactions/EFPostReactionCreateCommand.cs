using Application.Exeptions;
using Application.UseCases.Commands.PostReactions;
using Application.UseCases.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.PostReactions
{
    public class EFPostReactionCreateCommand : EFUseCase, ICreatePostReaction
    {
        private readonly IApplicationUser _user;
        public EFPostReactionCreateCommand(BlogContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 37;

        public string Name => "Create Post Reaction";

        public string Description => "Create Post Reaction using Entity Framework";

        public void Execute(PostReactionDto request)
        {
            var post = Context.Posts.Find(request.PostId);

            if(post == null)
            {
                throw new NotFoundException("Post", request.PostId);
            }

            var user = Context.Users.Find(request.UserId);

            if(user == null)
            {
                throw new NotFoundException("User", request.UserId);
            }

            if(user.Id != _user.Id)
            {
                throw new UnauthorizedAccessException();
            }

            var reaction = Context.Reactions.Find(request.ReactionId);

            if (reaction == null)
            {
                throw new NotFoundException("Reaction", request.ReactionId);
            }

            var postReaction = new Domain.Entities.PostReaction
            {
                Post = post,
                Reaction = reaction,
                User = user
            };

            Context.PostReactions.Add(postReaction);
            Context.SaveChanges();

        }
    }
}
