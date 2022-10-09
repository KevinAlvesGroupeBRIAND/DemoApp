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
                        Name = "Site 2 (C2)"
                    }
                }
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("C2");
            result.Name.ShouldBe("Company 2");
            result.Sites.Count().ShouldBe(2);
        }
        

        [Fact]
        public async Task Should_Create_Companies()
        {
            var result = await _companyService.CreateCompaniesAsync(new List<CreateCompanyDto> {
                new CreateCompanyDto
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
                            Name = "Site 2 (C2)"
                        }
                    }
                },
                new CreateCompanyDto
                {
                    Code = "C3",
                    Name = "Company 3",
                    Sites = new List<SiteOfCreateCompanyDto>
                    {
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C3_S1",
                            Name = "Site 1 (C3)"
                        },
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C3_S2",
                            Name = "Site 2 (C3)"
                        },
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C3_S3",
                            Name = "Site 3 (C3)"
                        }
                    }
                }
            });

            result.Count().ShouldBe(2);

            var result0 = result.ElementAt(0);
            result0.Id.ShouldNotBe(Guid.Empty);
            result0.Code.ShouldBe("C2");
            result0.Name.ShouldBe("Company 2");
            result0.Sites.Count().ShouldBe(2);

            var result1 = result.ElementAt(1);
            result1.Id.ShouldNotBe(Guid.Empty);
            result1.Code.ShouldBe("C3");
            result1.Name.ShouldBe("Company 3");
            result1.Sites.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Should_Update_Company()
        {
            var company = await _companyService.GetByCodeAsync("C1");
            var siteToUpdate = company.Sites.ElementAt(0);

            var result = await _companyService.UpdateAsync(company.Id, new UpdateCompanyDto
            {
                Code = "C1",
                Name = "Company 1 (Edited)",
                Sites = new List<SiteOfUpdateCompanyDto> {
                    new SiteOfUpdateCompanyDto
                    {
                        Id = siteToUpdate.Id,
                        Code = "S1_C1",
                        Name = "Site 1 (C1) (Edited)"
                    },
                    new SiteOfUpdateCompanyDto
                    {
                        Code = "S3_C1",
                        Name = "Site 3 (C1)"
                    }
                }
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("C1");
            result.Name.ShouldBe("Company 1 (Edited)");
            result.Sites.Count().ShouldBe(2);
        }
    }
}
