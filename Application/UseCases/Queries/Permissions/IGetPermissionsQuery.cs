using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Permissions
{
    public interface IGetPermissionsQuery : IQuery<SearchDto, PagedResponse<CommonDto>>
    {
    }
}
