using DemoApp.Companies.Childs;
using DemoApp.Sites;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Guids;
using Xunit;

namespace DemoApp.Companies
{
    public class CompanyServiceTests : DemoAppApplicationTestBase
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICompanyService _companyService;

        public CompanyServiceTests()
        {
            _guidGenerator = GetRequiredService<IGuidGenerator>();
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
                Code = "C20",
                Name = "Company 20", 
                Sites = new List<SiteOfCreateCompanyDto>
                {
                    new SiteOfCreateCompanyDto
                    {
                        Code = "C20_S1",
                        Name = "Site 1 (C20)"
                    },
                    new SiteOfCreateCompanyDto
                    {
                        Code = "C20_S2",
                        Name = "Site 2 (C20)"
                    }
                }
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("C20");
            result.Name.ShouldBe("Company 20");
            result.Sites.Count().ShouldBe(2);

            var result0 = result.Sites.ElementAt(0);
            result0.Id.ShouldNotBe(Guid.Empty);

            var result1 = result.Sites.ElementAt(1);
            result1.Id.ShouldNotBe(Guid.Empty);
        }
        

        [Fact]
        public async Task Should_Create_Companies()
        {
            var result = await _companyService.CreateCompaniesAsync(new List<CreateCompanyDto> {
                new CreateCompanyDto
                {
                    Code = "C10",
                    Name = "Company 10",
                    Sites = new List<SiteOfCreateCompanyDto>
                    {
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C10_S1",
                            Name = "Site 1 (C10)"
                        },
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C10_S2",
                            Name = "Site 2 (C10)"
                        }
                    }
                },
                new CreateCompanyDto
                {
                    Code = "C11",
                    Name = "Company 11",
                    Sites = new List<SiteOfCreateCompanyDto>
                    {
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C11_S1",
                            Name = "Site 1 (C11)"
                        },
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C11_S2",
                            Name = "Site 2 (C11)"
                        },
                        new SiteOfCreateCompanyDto
                        {
                            Code = "C11_S3",
                            Name = "Site 3 (C11)"
                        }
                    }
                }
            });

            result.Count().ShouldBe(2);

            var result0 = result.ElementAt(0);
            result0.Id.ShouldNotBe(Guid.Empty);
            result0.Code.ShouldBe("C10");
            result0.Name.ShouldBe("Company 10");
            result0.Sites.Count().ShouldBe(2);

            var result1 = result.ElementAt(1);
            result1.Id.ShouldNotBe(Guid.Empty);
            result1.Code.ShouldBe("C11");
            result1.Name.ShouldBe("Company 11");
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
                        Id = _guidGenerator.Create(),
                        Code = "S3_C1",
                        Name = "Site 3 (C1)"
                    },
                    new SiteOfUpdateCompanyDto
                    {
                        Id = _guidGenerator.Create(),
                        Code = "S4_C1",
                        Name = "Site 4 (C1)"
                    }
                }
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("C1");
            result.Name.ShouldBe("Company 1 (Edited)");
            result.Sites.Count.ShouldBe(3);

            var result0 = result.Sites.ElementAt(0);
            result0.Id.ShouldNotBe(Guid.Empty);

            var result1 = result.Sites.ElementAt(1);
            result1.Id.ShouldNotBe(Guid.Empty);

            var result2 = result.Sites.ElementAt(2);
            result2.Id.ShouldNotBe(Guid.Empty);
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
                                //Id = siteToUpdate1.Id,
                                Code = "C1_S1",
                                Name = "Site 1 (C1) (Edited)",
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
                                //Id = siteToUpdate2.Id,
                                Code = "C2_S1",
                                Name = "Site 1 (C2) (Edited)"
                            },
                            new SiteOfUpdateCompanyDto
                            {
                                Code = "C2_S3",
                                Name = "Site 3 (C2)"
                            },
                            new SiteOfUpdateCompanyDto
                            {
                                Code = "C2_S4",
                                Name = "Site 4 (C2)"
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
