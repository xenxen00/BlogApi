using Application.UseCases.DTO;
using Application.UseCases.Queries.Categories;
using Application.UseCases.Queries.Common;
using DataAccess;

namespace Implementation.UseCases.Queries.EF.Categories
{
    public class EFGetCategoriesQuery : EFUseCase, IGetCategoriesQuery
    {
        public EFGetCategoriesQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "";

        public string Description => "";

        public IEnumerable<CommonDto> Execute()
        {
            var categories = Context.Categories.Where(x => x.Active == true);

            var data = categories.Select(x => new CommonDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return data;
        }
    }
}
