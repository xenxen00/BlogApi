using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Tags
{
    public interface IGetTagsQuery : IQuery<SearchDto, PagedResponse<CommonDto>>
    {
    }
}
