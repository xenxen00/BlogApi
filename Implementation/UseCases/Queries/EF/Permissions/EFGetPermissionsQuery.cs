using Application.UseCases.DTO;
using Application.UseCases.Queries.Common;
using Application.UseCases.Queries.Permissions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.EF.Permissions
{
    public class EFGetPermissionsQuery : EFUseCase, IGetPermissionsQuery
    {
        public EFGetPermissionsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "";

        public string Description => "";

        public IEnumerable<CommonDto> Execute()
        {
            var permissions = Context.Permissions.Where(x => x.Active == true);

            var data = permissions.Select(x => new CommonDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return data;
        }
    }
}
