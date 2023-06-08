using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class PagedResponse<T>
    {
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public int NumberOfPages => (int)Math.Ceiling((float)Count / PageSize);

        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
