using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Images;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Images
{
    public class EFDeleteImageCommand : EFUseCase, IDeleteImageCommand
    {
        private readonly IApplicationUser _user;
        public EFDeleteImageCommand(BlogContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 39;

        public string Name => "Delete image";

        public string Description => "Delete image using EF";

        public void Execute(int request)
        {
            var image = Context.Images.Where(x => x.Id == request).FirstOrDefault();

            var imagepost = Context.Posts.Find(image.PostId);

            if(imagepost.AuthorId != _user.Id)
            {
                throw new ForbiddenUseCase();
            }

            if (image == null)
            {
                throw new NotFoundException("Image", request);
            }

            if (image.Active == false)
            {
                throw new NotFoundException("Image", request);
            }

            image.Active = false;
            Context.SaveChanges();
        }
    }
}
