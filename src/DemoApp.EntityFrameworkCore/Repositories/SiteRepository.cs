using DemoApp.EntityFrameworkCore;
using DemoApp.RepositoryExtensions;
using DemoApp.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DemoApp.Repositories
{
    public class SiteRepository
        : EfCoreRepository<DemoAppDbContext, Site, Guid>, ISiteRepository
    {
        public SiteRepository(IDbContextProvider<DemoAppDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Site>> WithDetailsAsync()
        {
            var query = await GetQueryableAsync();
            return query.IncludeDetails();
        }
    }
}
