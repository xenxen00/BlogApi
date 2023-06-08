using Application.UseCases.Commands.Comments;
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

namespace Implementation.UseCases.Commands.EF.Comments
{
    public class EFCreateCommentCommand : EFUseCase, ICreateCommentCommand
    {
        private readonly CreateCommentValidator _validator;


        public EFCreateCommentCommand(BlogContext context, CreateCommentValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 29;

        public string Name => "Create comment";

        public string Description => "Create comment using EF";

        public void Execute(CreateCommentDto request)
        {
            _validator.ValidateAndThrow(request);

            var parentComment = Context.Comments.Find(request.ParentCommentId);
            var post = Context.Posts.Find(request.PostId);
            var author = Context.Users.Find(request.AuthorId);

            var newComment = new Domain.Entities.Comment
            {
               Content = request.Content,
               ParentComment = parentComment,
               Post = post,
               Author = author
            };

            Context.Comments.Add(newComment);
            Context.SaveChanges();
        }
    }
}
