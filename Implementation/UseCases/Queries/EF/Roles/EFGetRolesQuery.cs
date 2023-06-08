using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Roles;
using DataAccess;
using Domain.Entities;
using Implementation.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Queries.EF.Roles
{
    public class EFGetRolesQuery : EFUseCase, IGetRolesQuery
    {
        public EFGetRolesQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "";

        public string Description => "";

        public PagedResponse<RoleDto> Execute(SearchDto request)
        {
            IQueryable<Role> roles = Context.Roles.Include(x => x.RolePermissions).ThenInclude(x => x.Permission);

            var data = roles.GetPagedResponse<Role, RoleDto>(request, x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name,
                Permissions = x.RolePermissions.Select(y => new PermissionDto
                {
                    Id = y.Permission.Id,
                    Name = y.Permission.Name,
                    Description = y.Permission.Description
                }).ToList()
            });
            
            return data;
        }
    }
}
