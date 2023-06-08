using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Categories;
using DataAccess;
using Domain.Entities;
using Implementation.Extentions;

namespace Implementation.UseCases.Queries.EF.Categories
{
    public class EFGetCategoriesQuery : EFUseCase, IGetCategoriesQuery
    {
        public EFGetCategoriesQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Get categories";

        public string Description => "Get categories using EF";

        public PagedResponse<CommonDto> Execute(SearchDto request)
        {
            IQueryable<Category> categories = Context.Categories.Where(x => x.Active == true);


            if (!String.IsNullOrEmpty(request.keyword))
            {
                categories = categories.Where(x => x.Name.Contains(request.keyword));
            }

            var data = categories.GetPagedResponse<Category, CommonDto>(request, x => new CommonDto
            {
                Id = x.Id,
                Name = x.Name
            });

            return data;
        }
    }
}
