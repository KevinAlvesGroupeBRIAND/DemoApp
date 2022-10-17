using DemoApp.Companies;
using DemoApp.EntityFrameworkCore;
using DemoApp.RepositoryExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DemoApp.Repositories
{
    public class CompanyRepository
        : EfCoreRepository<DemoAppDbContext, Company, Guid?>, ICompanyRepository
    {
        public CompanyRepository(IDbContextProvider<DemoAppDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Company>> WithDetailsAsync()
        {
            var query = await GetQueryableAsync();
            return query.IncludeDetails();
        }
    }
}
