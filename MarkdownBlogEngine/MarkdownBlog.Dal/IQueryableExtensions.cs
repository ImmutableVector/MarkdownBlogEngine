using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownBlog.Shared
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int skip, int take)
        {
            var pagedList = new PagedList<T>()
            {
                HasNext = await source
                    .Skip(skip + take)
                    .Take(1)
                    .AnyAsync(),
                Data = await source
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync(),
                Skip = skip,
                Take = take,
            };

            return pagedList;
        }
    }
}
