using DemoApp.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.RepositoryExtensions
{
    public static class CompanyRepositoryExtension
    {
        public static IQueryable<Company> IncludeDetails(this IQueryable<Company> query, bool include = false)
        { 
            if (!include)
                return query;

            return query
                .Include(x => x.Sites);
        }
    }
}
