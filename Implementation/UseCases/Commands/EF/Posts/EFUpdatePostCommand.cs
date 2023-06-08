using Application.UseCases.Commands.Posts;
using Application.UseCases.DTO;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Posts
{
    public class EFUpdatePostCommand : EFUseCase, IUpdatePostCommand
    {
        private readonly UpdatePostValidator _validator;
        private readonly ImageValdiator _imageValidator;

        public EFUpdatePostCommand(BlogContext context, UpdatePostValidator validator, ImageValdiator imageValidator) : base(context)
        {
            _validator = validator;
            _imageValidator = imageValidator;
        }

        public int Id => 6;

        public string Name => "Update Post";

        public string Description => "Update Post using EF";

        public void Execute(UpdatePostDto request)
        {
            _validator.ValidateAndThrow(request);

            var post = Context.Posts.Find(request.Id);

            foreach (var image in request.Images)
            {
                _imageValidator.ValidateAndThrow(image);
            }

            List<Tag> tags = new List<Tag>();

            foreach (var tag in request.Tags)
            {
                Tag tagExists = Context.Tags.Where(x => x.Name == tag.Name).FirstOrDefault();

                if (tagExists == null)
                {
                    Context.Tags.Add(new Tag
                    {
                        Name = tag.Name
                    });
                }

                tags.Add(tag);
            }

            post.Author = Context.Users.Find(request.AuthorId);
            post.Content = request.Content;
            post.Category = Context.Categories.Find(request.CategoryId);
            post.PostTags = tags.Select(x => new PostTag
            {
                Post = post,
                Tag = x
            }).ToList();

            Context.Images.AddRange(request.Images.Select(x => new Image
            {
                Path = x.Path,
                Post = post
            }).ToList());

            Context.SaveChanges();

        }
    }
}
