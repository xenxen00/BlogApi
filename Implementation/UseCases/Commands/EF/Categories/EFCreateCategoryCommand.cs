using Application.UseCases.Commands.Categories;
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

namespace Implementation.UseCases.Commands.EF.Categories
{
    public class EFCreateCategoryCommand : EFUseCase, ICreateCategoryCommand
    {
        private readonly CategoryValidator _validator;
        public EFCreateCategoryCommand(BlogContext context, CategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Create Category";

        public string Description => "Create Category using EF";

        public void Execute(CreateEntityDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.Add(new Category
            {
                Name = request.Name,
            });

            Context.SaveChanges();
        }
    }
}
