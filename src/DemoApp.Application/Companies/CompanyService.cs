using DemoApp.Sites;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DemoApp.Companies
{
    [AllowAnonymous]
    public class CompanyService : ApplicationService, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDto> CreateAsync(CreateCompanyDto input)
        {
            var entity = ObjectMapper.Map<CreateCompanyDto, Company>(input);
            entity = await _companyRepository.InsertAsync(entity);
            return ObjectMapper.Map<Company, CompanyDto>(entity);
        }

        public async Task<IEnumerable<CompanyDto>> CreateCompaniesAsync(IEnumerable<CreateCompanyDto> input)
        {
            var entities = ObjectMapper.Map<IEnumerable<CreateCompanyDto>, IEnumerable<Company>>(input);
            await _companyRepository.InsertManyAsync(entities);
            return ObjectMapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var entities = await _companyRepository.GetListAsync(includeDetails: true);
            return ObjectMapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);
        }

        public async Task<CompanyDto> GetAsync(Guid id)
        {
            var entity = await _companyRepository.GetAsync(id, includeDetails: true);
            return ObjectMapper.Map<Company, CompanyDto>(entity);
        }

        public async Task<CompanyDto> GetByCodeAsync(string code)
        {
            var entity = await _companyRepository.GetAsync(o => o.Code == code, includeDetails: true);
            return ObjectMapper.Map<Company, CompanyDto>(entity);
        }

        public async Task<CompanyDto> UpdateAsync(Guid id, UpdateCompanyDto input)
        {
            var entity = await _companyRepository.GetAsync(id, includeDetails: true);
            entity = ObjectMapper.Map(input, entity);
            entity = await _companyRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Company, CompanyDto>(entity);
        }

        public async Task<IEnumerable<CompanyDto>> UpdateCompaniesAsync(IDictionary<Guid, UpdateCompanyDto> input)
        {
            // WARNING: DO NOT USE "ContainsKey" BECAUSE EF DOES NOT SUPPORT THIS METHOD...
            var entities = await _companyRepository.GetListAsync(o => input.Keys.Contains(o.Id));
            entities = ObjectMapper.Map(input.Values, entities);
            await _companyRepository.UpdateManyAsync(entities);
            return ObjectMapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);
        }
    }
}
