using DemoApp.Sites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.RepositoryExtensions
{
    public static class SiteRepositoryExtension
    {
        public static IQueryable<Site> IncludeDetails(this IQueryable<Site> query, bool include = false)
        {
            if (!include)
                return query;

            return query
                .Include(x => x.Company);
        }

    }
}
