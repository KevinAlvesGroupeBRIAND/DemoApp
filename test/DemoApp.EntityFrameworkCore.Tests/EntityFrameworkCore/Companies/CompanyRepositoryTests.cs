using DemoApp.Companies;
using DemoApp.Sites;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Guids;
using Xunit;
using Xunit.Abstractions;

namespace DemoApp.EntityFrameworkCore.Companies
{
    public class CompanyRepositoryTests : DemoAppEntityFrameworkCoreTestBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IGuidGenerator _guidGenerator;

        public CompanyRepositoryTests()
        {
            _companyRepository = GetRequiredService<ICompanyRepository>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Companies()
        {
            var result = await _companyRepository.GetListAsync();

            result.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_Create_Company()
        {
            var result = await _companyRepository.InsertAsync(new Company
            {
                Code = "CTEST",
                Name = "Company TEST",
                Sites = new List<Site>
                {
                    new Site(_guidGenerator.Create())
                    {
                        Code = "STEST1",
                        Name = "Site TEST 1"
                    },
                    new Site(_guidGenerator.Create())
                    {
                        Code = "STEST2",
                        Name = "Site TEST 2"
                    }
                }
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("CTEST");
            result.Name.ShouldBe("Company TEST");
            result.Sites.Count.ShouldBe(2);

            var rchild0 = result.Sites.ElementAt(0);
            rchild0.Id.ShouldNotBe(Guid.Empty);
            rchild0.Code.ShouldBe("STEST1");
            rchild0.Name.ShouldBe("Site TEST 1");

            var rchild1 = result.Sites.ElementAt(1);
            rchild1.Id.ShouldNotBe(Guid.Empty);
            rchild1.Code.ShouldBe("STEST2");
            rchild1.Name.ShouldBe("Site TEST 2");
        }

        [Fact]
        public async Task Should_Create_Companies()
        {
            var entities = new List<Company> {
                    new Company
                    {
                        Code = "CTEST1",
                        Name = "Company TEST1",
                        Sites = new List<Site>
                        {
                            new Site(_guidGenerator.Create())
                            {
                                Code = "STEST1",
                                Name = "Site TEST 1"
                            },
                            new Site(_guidGenerator.Create())
                            {
                                Code = "STEST2",
                                Name = "Site TEST 2"
                            }
                        }
                    },
                    new Company
                    {
                        Code = "CTEST2",
                        Name = "Company TEST2",
                        Sites = new List<Site>
                        {
                            new Site(_guidGenerator.Create())
                            {
                                Code = "STEST3",
                                Name = "Site TEST 3"
                            },
                            new Site(_guidGenerator.Create())
                            {
                                Code = "STEST4",
                                Name = "Site TEST 4"
                            }
                        }
                    }
                };

            await _companyRepository.InsertManyAsync(entities, autoSave: true);

            var result0 = entities.ElementAt(0);
            result0.Id.ShouldNotBe(Guid.Empty);
            result0.Code.ShouldBe("CTEST1");
            result0.Name.ShouldBe("Company TEST1");
            result0.Sites.Count.ShouldBe(2);

            var rchild0 = result0.Sites.ElementAt(0);
            rchild0.Id.ShouldNotBe(Guid.Empty);
            rchild0.Code.ShouldBe("STEST1");
            rchild0.Name.ShouldBe("Site TEST 1");

            var rchild1 = result0.Sites.ElementAt(1);
            rchild1.Id.ShouldNotBe(Guid.Empty);
            rchild1.Code.ShouldBe("STEST2");
            rchild1.Name.ShouldBe("Site TEST 2");
        }
        
        [Fact]
        public async Task Should_Update_Company()
        {
            var currentCompany = await _companyRepository.GetAsync(o => o.Code == "C1", includeDetails: true);
            currentCompany.Code = "CTEST";
            currentCompany.Name = "Company TEST";
            currentCompany.Sites = new List<Site>
            {
                new Site(_guidGenerator.Create())
                {
                    Code = "STEST1",
                    Name = "Site TEST 1"
                },
                new Site(_guidGenerator.Create())
                {
                    Code = "STEST2",
                    Name = "Site TEST 2"
                }
            };

            var result = await _companyRepository.UpdateAsync(currentCompany);

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("CTEST");
            result.Name.ShouldBe("Company TEST");
            result.Sites.Count.ShouldBe(2);

            var rchild0 = result.Sites.ElementAt(0);
            rchild0.Id.ShouldNotBe(Guid.Empty);
            rchild0.Code.ShouldBe("STEST1");
            rchild0.Name.ShouldBe("Site TEST 1");

            var rchild1 = result.Sites.ElementAt(1);
            rchild1.Id.ShouldNotBe(Guid.Empty);
            rchild1.Code.ShouldBe("STEST2");
            rchild1.Name.ShouldBe("Site TEST 2");
        }
    }
}
