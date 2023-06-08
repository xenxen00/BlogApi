using Application.UseCases.DTO;
using Application.UseCases.Queries.Common;
using Application.UseCases.Queries.Tags;
using DataAccess;

namespace Implementation.UseCases.Queries.EF.Tags
{
    public class EFGetTagsQuery : EFUseCase, IGetTagsQuery
    {
        public EFGetTagsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "";

        public string Description => "";

        public IEnumerable<CommonDto> Execute()
        {
            var tags = Context.Tags.Where(x => x.Active == true);

            var data = tags.Select(x => new CommonDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return data;
        }
    }
}
