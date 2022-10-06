using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DemoApp.Companies
{
    public interface ICompanyService : IApplicationService
    {
        // SCRUD
        public Task<CompanyDto> GetAsync(Guid id);

        public Task<IEnumerable<CompanyDto>> GetAllAsync();

        public Task<CompanyDto> CreateAsync(CreateCompanyDto input);

        public Task<CompanyDto> UpdateAsync(Guid id, UpdateCompanyDto input);

        public Task DeleteAsync(Guid id);

        // ADDITIONAL METHODS
        public Task<IEnumerable<CompanyDto>> CreateCompaniesAsync(IEnumerable<CreateCompanyDto> input);

        public Task<IEnumerable<CompanyDto>> UpdateCompaniesAsync(IDictionary<Guid, UpdateCompanyDto> input);
    }
}
