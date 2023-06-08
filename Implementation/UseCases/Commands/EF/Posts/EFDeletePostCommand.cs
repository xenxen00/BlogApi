using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.PostReactions;
using Application.UseCases.Commands.Posts;
using Application.UseCases.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Posts
{
    public class EFDeletePostCommand : EFUseCase, IDeletePostCommand
    {

        public int Id => 5;

        public string Name => "Delete Post";

        public string Description => "Delete Post using EF";

        public EFDeletePostCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var post = Context.Posts.Where(x => x.Id == request).FirstOrDefault();

            if(post == null)
            {
                throw new NotFoundException("Post", request);
            }

            post.Active = false;
            Context.SaveChanges();
        }
    }
}
