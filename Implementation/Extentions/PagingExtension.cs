using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Extentions
{
    public static class PagingExtension
    {
        public static PagedResponse<T> GetPagedResponse<TEntity, T>(
           this IQueryable<TEntity> query, PagedSearch searchDto, Expression<Func<TEntity, T>> convert)
        {
            if(searchDto.PageNumber < 1)
            {
                searchDto.PageNumber = 1;
            }

            if(searchDto.PageSize < 1)
            {
                searchDto.PageSize = 10;
            }

            var skip = (searchDto.PageNumber - 1) * searchDto.PageSize;

            return new PagedResponse<T>
            {
                Count = query.Count(),
                PageNumber = searchDto.PageNumber,
                PageSize = searchDto.PageSize,
                Items = query.Skip(skip)
                .Take(searchDto.PageSize)
                             .Select(convert)
                             .ToList()
            };
        }
    }
}
