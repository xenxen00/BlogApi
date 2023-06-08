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
    public class EFCreatePostCommand : EFUseCase, ICreatePostCommand
    {
        private readonly PostValidator _postValidator;
        private readonly ImageValdiator _imageValidator;

        public int Id => 4;

        public string Name => "Create a new Post (EF)";

        public string Description => "Creats a new Post using Entity Framework";

        public EFCreatePostCommand(BlogContext context, PostValidator validator, ImageValdiator imageValidator) : base(context)
        {
            _postValidator = validator;
            _imageValidator = imageValidator;
        }

        public void Execute(CreatePostDto request)
        {
            _postValidator.ValidateAndThrow(request);

            foreach(var image in request.Images)
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

            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                CategoryId = request.CategoryId,
                AuthorId = request.AuthorId,
                PostTags = tags.Select(x => new PostTag
                {
                    Tag = x
                }).ToList()
            };

            Context.Images.AddRange(request.Images.Select(x => new Image
            {
                Path = x.Path,
                Post = post
            }).ToList());

            Context.Posts.Add(post);

            Context.SaveChanges();
        }
    }
}
