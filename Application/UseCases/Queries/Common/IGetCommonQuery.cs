using Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Common
{
    public interface IGetCommonQuery: IEmptyQuery<IEnumerable<CommonDto>>
    {
    }
}
