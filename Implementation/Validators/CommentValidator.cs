using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator(BlogContext context)
        {
            RuleFor(x => x.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Author is required.")
                .Must(x => context.Users.Any(y => y.Id == x))
                .WithMessage("Invalid user.");

            RuleFor(x => x.PostId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post id is required.")
                .Must(x => context.Posts.Any(y => y.Id == x))
                .WithMessage("Invalid Post.");

        }

    }

    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentValidator(BlogContext context)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Comment id is required.")
                .Must(x => context.Comments.Any(y => y.Id == x))
                .WithMessage("Invalid Comment.");

            RuleFor(x => x.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Author is required.")
                .Must(x => context.Users.Any(y => y.Id == x))
                .WithMessage("Invalid user.");

            RuleFor(x => x.PostId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post id is required.")
                .Must(x => context.Posts.Any(y => y.Id == x))
                .WithMessage("Invalid Post.");
        }
    }

}
