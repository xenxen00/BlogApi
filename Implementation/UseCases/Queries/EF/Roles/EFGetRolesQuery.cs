using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Roles;
using DataAccess;
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

        public IEnumerable<RoleDto> Execute()
        {
            var roles = Context.Roles.Include(x => x.RolePermissions).ThenInclude(x => x.Permission);

            var data = roles.Select(x => new RoleDto
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
