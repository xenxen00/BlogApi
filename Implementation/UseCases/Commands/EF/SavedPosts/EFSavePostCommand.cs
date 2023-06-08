using Application.Exeptions;
using Application.UseCases.Commands.SavedPosts;
using Application.UseCases.DTO;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.SavedPosts
{
    public class EFSavePostCommand : EFUseCase, ISavePostCommand
    {
        public EFSavePostCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 32;

        public string Name => "Saves a post to a reading list";

        public string Description => "Adds a post to reading list using EF";

        public void Execute(SavedPostDto request)
        {
            if(!Context.Posts.Any(x => x.Id == request.PostId))
            {
                throw new NotFoundException("Post", request.PostId);
            }

            if (!Context.Users.Any(x => x.Id == request.UserId))
            {
                throw new NotFoundException("User", request.UserId);
            }

            var existingSavedPost = Context.SavedPosts.Where(x => x.UserId == request.UserId && x.PostId == request.PostId).FirstOrDefault();

            if (existingSavedPost != null)
            {
                existingSavedPost.Active = true;
            }
            else
            {
                var savedPost = new SavedPost
                {
                    PostId = request.PostId,
                    UserId = request.UserId
                };

                Context.SavedPosts.Add(savedPost);
            }

            Context.SaveChanges();
        }
    }
}
