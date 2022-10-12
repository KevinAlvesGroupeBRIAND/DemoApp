using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DemoApp.Companies
{
    public interface ICompanyService 
        : ICrudAppService<CompanyDto, Guid, PagedAndSortedResultRequestDto, CreateCompanyDto, UpdateCompanyDto>
    {
        public Task<CompanyDto> GetByCodeAsync(string code);

        public Task<IEnumerable<CompanyDto>> GetAllAsync();

        public Task<IEnumerable<CompanyDto>> CreateCompaniesAsync(IEnumerable<CreateCompanyDto> input);

        public Task<IEnumerable<CompanyDto>> UpdateCompaniesAsync(IDictionary<Guid, UpdateCompanyDto> input);
    }
}
