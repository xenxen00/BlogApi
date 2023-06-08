using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Roles
{
    public interface IGetRolesQuery: IEmptyQuery<IEnumerable<RoleDto>>
    {
    }
}
