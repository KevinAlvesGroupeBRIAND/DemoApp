using DemoApp.Companies;
using DemoApp.Sites;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace DemoApp;

public class DemoAppTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ICompanyRepository _companyRepository;

    public DemoAppTestDataSeedContributor(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public Task SeedAsync(DataSeedContext context)
    {
        var taskCompany1 = GetCompany1();
        var i = taskCompany1.Result;

        return Task.CompletedTask;
    }

    private async Task<Company> GetCompany1()
    {
        return await _companyRepository.InsertAsync(new Company
        {
            Code = "C1",
            Name = "Company 1",
            Sites = new List<Site>
            {
                new Site
                {
                    Code = "C1_S1",
                    Name = "Site 1 (C1)"
                },
                new Site
                {
                    Code = "C1_S2",
                    Name = "Site 2 (C1)"
                },
            }
        });
    }
}
