using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Comments;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Implementation.UseCases.Commands.EF.Comments
{
    public class EFDeleteCommentCommand : EFUseCase, IDeleteCommentCommand
    {
        public EFDeleteCommentCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Delete comment";

        public string Description => "Delete comment using EF";

        public void Execute(int request)
        {
            var comment = Context.Comments.Find(request);

            if (comment == null)
            {
                throw new NotFoundException("Comment", request);
            }

            if (comment.Active == false)
            {
                throw new NotFoundException("Comment", request);
            }

            comment.Active = false;
            Context.SaveChanges();
        }
    }
}
