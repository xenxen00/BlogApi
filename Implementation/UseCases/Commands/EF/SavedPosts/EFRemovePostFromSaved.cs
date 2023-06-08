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
    public class EFRemovePostFromSaved : EFUseCase, IRemovePostFromSavedCommand
    {
        public EFRemovePostFromSaved(BlogContext context) : base(context)
        {
        }

        public int Id => 34;

        public string Name => "";

        public string Description => "";

        public void Execute(SavedPostDto request)
        {
            var savedPost = Context.SavedPosts.Where(x => x.PostId == request.PostId && x.UserId == request.UserId).FirstOrDefault();

            if (savedPost == null)
            {
                throw new NotFoundException("Saved post", request.PostId);
            }

            savedPost.Active = false;
            Context.SaveChanges();
        }
    }
}
