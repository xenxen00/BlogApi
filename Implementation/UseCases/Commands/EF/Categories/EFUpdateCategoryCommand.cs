using Application.UseCases.Commands;
using Application.UseCases.Commands.Categories;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Categories
{
    public class EFUpdateCategoryCommand : EFUseCase, IUpdateCategoryCommand
    {
        private readonly UpdateCategoryValidator _validator;
        public EFUpdateCategoryCommand(BlogContext context, UpdateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Update Category";

        public string Description => "Update Category using EF";

        public void Execute(UpdateEntityDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = Context.Categories.Find(request.Id);

            category.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
