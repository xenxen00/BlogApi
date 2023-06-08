using Application.UseCases.DTO;
using Application.UseCases.Queries;
using Application.UseCases.Queries.Common;
using DataAccess;

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

        public IEnumerable<CommonDto> Execute()
        {
            var reactions = Context.Reactions.Where(x => x.Active == true);

            var data = reactions.Select(x => new CommonDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return data;
        }
    }
}
