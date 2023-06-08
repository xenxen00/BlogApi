using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO.Searches
{
    public class PagedSearch
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
