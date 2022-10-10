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
                Code = "C100",
                Name = "Company 100", 
                Sites = new List<SiteOfCreateCompanyDto>
                {
                    new SiteOfCreateCompanyDto
                    {
                        Code = "C100_S1",
                        Name = "Site 1 (C100)"
                    },
                    new SiteOfCreateCompanyDto
                    {
                        Code = "C100_S2",
                        Name = "Site 2 (C100)"
                    }
                }
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("C100");
            result.Name.ShouldBe("Company 100");
            result.Sites.Count().ShouldBe(2);
        }
        

        [Fact]
        public async Task Should_Create_Companies()
        {
            var result = await _companyService.CreateCompaniesAsync(new List<CreateCompanyDto> {
                new CreateCompanyDto
                {
                    Code = "C100",
                    Name = "Company 100",
                    Sites = new List<SiteOfCreateCompanyDto>
                    {
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C100_S1",
                            Name = "Site 1 (C100)"
                        },
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C100_S2",
                            Name = "Site 2 (C100)"
                        }
                    }
                },
                new CreateCompanyDto
                {
                    Code = "C101",
                    Name = "Company 101",
                    Sites = new List<SiteOfCreateCompanyDto>
                    {
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C101_S1",
                            Name = "Site 1 (C101)"
                        },
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C101_S2",
                            Name = "Site 2 (C101)"
                        },
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C101_S3",
                            Name = "Site 3 (C101)"
                        }
                    }
                }
            });

            result.Count().ShouldBe(2);

            var result0 = result.ElementAt(0);
            result0.Id.ShouldNotBe(Guid.Empty);
            result0.Code.ShouldBe("C100");
            result0.Name.ShouldBe("Company 100");
            result0.Sites.Count().ShouldBe(2);

            var result1 = result.ElementAt(1);
            result1.Id.ShouldNotBe(Guid.Empty);
            result1.Code.ShouldBe("C101");
            result1.Name.ShouldBe("Company 101");
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
                        Code = "C1_S1",
                        Name = "Site 1 (C1) (Edited)"
                    },
                    new SiteOfUpdateCompanyDto
                    {
                        Code = "C1_S3",
                        Name = "Site 3 (C1)"
                    }
                }
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("C1");
            result.Name.ShouldBe("Company 1 (Edited)");
            result.Sites.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Should_Update_Companies()
        {
            var company1 = await _companyService.GetByCodeAsync("C1");
            var siteToUpdate1 = company1.Sites.ElementAt(0);
            var company2 = await _companyService.GetByCodeAsync("C2");
            var siteToUpdate2 = company2.Sites.ElementAt(0);

            var result = await _companyService.UpdateCompaniesAsync(new Dictionary<Guid, UpdateCompanyDto>
            {
                {
                    company1.Id,
                    new UpdateCompanyDto
                    {
                        Code = "C1",
                        Name = "Company 1 (Edited)",
                        Sites = new List<SiteOfUpdateCompanyDto> {
                            new SiteOfUpdateCompanyDto
                            {
                                Id = siteToUpdate2.Id,
                                Code = "C1_S1",
                                Name = "Site 1 (C1) (Edited)"
                            },
                            new SiteOfUpdateCompanyDto
                            {
                                Code = "C1_S3",
                                Name = "Site 3 (C1)"
                            }
                        }
                    }
                },
                {
                    company2.Id,
                    new UpdateCompanyDto
                    {
                        Code = "C2",
                        Name = "Company 2 (Edited)",
                        Sites = new List<SiteOfUpdateCompanyDto> {
                            new SiteOfUpdateCompanyDto
                            {
                                Id = siteToUpdate1.Id,
                                Code = "C2_S1",
                                Name = "Site 1 (C2) (Edited)"
                            },
                            new SiteOfUpdateCompanyDto
                            {
                                Code = "C2_S3",
                                Name = "Site 3 (C1)"
                            }
                        }
                    }
                },
            });

            result.Count().ShouldBe(2);

            var result0 = result.ElementAt(0);
            result0.Id.ShouldNotBe(Guid.Empty);
            result0.Code.ShouldBe("C1");
            result0.Name.ShouldBe("Company 1 (Edited)");
            result0.Sites.Count().ShouldBe(2);

            var result1 = result.ElementAt(1);
            result1.Id.ShouldNotBe(Guid.Empty);
            result1.Code.ShouldBe("C2");
            result1.Name.ShouldBe("Company 2 (Edited)");
            result1.Sites.Count().ShouldBe(2);
        }
    }
}
