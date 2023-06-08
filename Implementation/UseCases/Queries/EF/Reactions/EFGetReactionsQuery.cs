using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries;
using DataAccess;
using Domain.Entities;
using Implementation.Extentions;

namespace Implementation.UseCases.Queries.EF.Reactions
{
    public class EFGetReactionsQuery : EFUseCase, IGetReactionsQuery
    {
        public EFGetReactionsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "";

        public string Description => "";

        public PagedResponse<CommonDto> Execute(SearchDto request)
        {
            IQueryable<Domain.Entities.Reaction> reactions = Context.Reactions.Where(x => x.Active == true);


            if (!String.IsNullOrEmpty(request.keyword))
            {
                reactions = reactions.Where(x => x.Name.Contains(request.keyword));
            }

            var data = reactions.GetPagedResponse<Domain.Entities.Reaction, CommonDto>(request, x => new CommonDto
            {
                Id = x.Id,
                Name = x.Name
            });

            return data;
        }
    }
}
