using DemoApp.Companies.Childs;
using DemoApp.Sites;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoApp.Companies
{
    public class CompanyServiceTests : DemoAppApplicationTestBase
    {
        private readonly ICompanyService _companyService;
        public CompanyServiceTests()
        {
            _companyService = GetRequiredService<ICompanyService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Companies()
        {
            var result = await _companyService.GetAllAsync();

            result.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_Get_Company()
        {
            var result = await _companyService.GetByCodeAsync("C1");

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("C1");
            result.Name.ShouldBe("Company 1");
            result.Sites.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Should_Create_Company()
        {
            var result = await _companyService.CreateAsync(new CreateCompanyDto
            {
                Code = "C2",
                Name = "Company 2",
                Sites = new List<SiteOfCreateCompanyDto>
                {
                    new SiteOfCreateCompanyDto
                    {
                        Code = "C2_S1",
                        Name = "Site 1 (C2)"
                    },
                    new SiteOfCreateCompanyDto
                    {
                        Code = "C2_S2",
                        Name = "Site 1 (C2)"
                    }
                }
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("C2");
            result.Name.ShouldBe("Company 2");
            result.Sites.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Should_Update_Company()
        {
            var company = await _companyService.GetByCodeAsync("C1");

        }
    }
}
