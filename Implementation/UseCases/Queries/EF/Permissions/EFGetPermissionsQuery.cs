using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Permissions;
using DataAccess;
using Domain.Entities;
using Implementation.Extentions;
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

        public string Name => "Gets list of permissions";

        public string Description => "Gets list of permissions using EF";

        public PagedResponse<CommonDto> Execute(SearchDto request)
        {
            IQueryable<Permission> permissions = Context.Permissions.Where(x => x.Active == true);

            if(!String.IsNullOrEmpty(request.keyword))
            {
                permissions = permissions.Where(x => x.Name.Contains(request.keyword));
            }

            var data = permissions.GetPagedResponse<Permission, CommonDto>(request, x => new CommonDto
            {
                Id = x.Id,
                Name = x.Name,
            });
            
            return data;
        }
    }
}
