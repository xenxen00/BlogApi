using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Categories
{
    public interface IGetCategoriesQuery: IQuery<SearchDto, PagedResponse<CommonDto>>
    {
    }
}
