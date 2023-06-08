using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Categories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Categories
{
    public class EFDeleteCategoryCommand : EFUseCase, IDeleteCategoryCommand
    {
        public EFDeleteCategoryCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Delete Category";

        public string Description => "Delete Category using EF";

        public void Execute(int request)
        {
            var category = Context.Categories.Where(x => x.Id == request).FirstOrDefault();

            if (category == null)
            {
                throw new NotFoundException("Category", request);
            }

            category.Active = false;
            Context.SaveChanges();
        }
    }
}
