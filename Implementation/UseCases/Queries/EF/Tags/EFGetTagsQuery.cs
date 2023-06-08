using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Tags;
using DataAccess;
using Domain.Entities;
using Implementation.Extentions;

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

        public PagedResponse<CommonDto> Execute(SearchDto request)
        {
            IQueryable<Tag> tags = Context.Tags.Where(x => x.Active == true);


            if (!String.IsNullOrEmpty(request.keyword))
            {
                tags = tags.Where(x => x.Name.Contains(request.keyword));
            }

            var data = tags.GetPagedResponse<Tag, CommonDto>(request, x => new CommonDto
            {
                Id = x.Id,
                Name = x.Name
            });

            return data;
        }
    }
}
