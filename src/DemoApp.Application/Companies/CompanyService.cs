using DemoApp.Sites;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DemoApp.Companies
{
    [AllowAnonymous]
    public class CompanyService 
        : CrudAppService<Company, CompanyDto, Guid, PagedAndSortedResultRequestDto, CreateCompanyDto, UpdateCompanyDto>, 
        ICompanyService
    {
        public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
        {
        }

        public async Task<IEnumerable<CompanyDto>> CreateCompaniesAsync(IEnumerable<CreateCompanyDto> input)
        {
            var entities = ObjectMapper.Map<IEnumerable<CreateCompanyDto>, IEnumerable<Company>>(input);
            await Repository.InsertManyAsync(entities);
            return ObjectMapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var entities = await Repository.GetListAsync(includeDetails: true);
            return ObjectMapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);
        }

        public async Task<CompanyDto> GetByCodeAsync(string code)
        {
            var entity = await Repository.GetAsync(o => o.Code == code, includeDetails: true);
            return ObjectMapper.Map<Company, CompanyDto>(entity);
        }

        public async Task<IEnumerable<CompanyDto>> UpdateCompaniesAsync(IDictionary<Guid, UpdateCompanyDto> input)
        {
            // WARNING: DO NOT USE "ContainsKey" BECAUSE EF DOES NOT SUPPORT THIS METHOD...
            var entities = await Repository.GetListAsync(o => input.Keys.Contains(o.Id));
            entities = ObjectMapper.Map(input.Values, entities);
            await Repository.UpdateManyAsync(entities);
            return ObjectMapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);
        }
    }
}
