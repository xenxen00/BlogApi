using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO.Searches
{
    public class SearchDto: PagedSearch
    {
        public string? keyword { get; set; }
    }
}
