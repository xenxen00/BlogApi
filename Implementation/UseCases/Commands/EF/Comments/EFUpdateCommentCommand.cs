using Application.UseCases.Commands.Comments;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Comments
{
    public class EFUpdateCommentCommand : EFUseCase, IUpdateCommentCommand
    {
        private readonly UpdateCommentValidator _validator;

        public EFUpdateCommentCommand(BlogContext context, UpdateCommentValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Update comment";

        public string Description => "Update comment using EF";

        public void Execute(UpdateCommentDto request)
        {
            _validator.ValidateAndThrow(request);

            var comment = Context.Comments.Find(request.Id);
            comment.Content = request.Content;

            Context.SaveChanges();
        }
    }
}
