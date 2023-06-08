using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class PostValidator : AbstractValidator<CreatePostDto>
    {
        public PostValidator(BlogContext context)
        {
            RuleFor(x => x.Content).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content is required");

            RuleFor(x => x.Title).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(x => x.AuthorId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Author is required")
                .Must(x => context.Users.Any(y => y.Id == x))
                .WithMessage("Invalid author id");

            RuleFor(x => x.CategoryId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category is required")
                .Must(x => context.Categories.Any(y => y.Id == x))
                .WithMessage("Invalid category id");
        }
    }


    public class UpdatePostValidator: AbstractValidator<UpdatePostDto>
    {
        public UpdatePostValidator(BlogContext context) 
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post id is required")
                .Must(x => context.Posts.Any(y => y.Id == x))
                .WithMessage("Invalid post id");

            RuleFor(x => x.Content).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content is required");

            RuleFor(x => x.Title).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(x => x.AuthorId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Author is required")
                .Must(x => context.Users.Any(y => y.Id == x))
                .WithMessage("Invalid author id");

            RuleFor(x => x.CategoryId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category is required")
                .Must(x => context.Categories.Any(y => y.Id == x))
                .WithMessage("Invalid category id");
        }
    }

    public class ImageValdiator : AbstractValidator<ImageDto>
    {
        public ImageValdiator(BlogContext context)
        {
            RuleFor(x => x.Path).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Image Path is required")
                .Must(x => !context.Images.Any(y => y.Path == x))
                .WithMessage("Image path {PropertyValue} already exists.");

        }
    }
}
