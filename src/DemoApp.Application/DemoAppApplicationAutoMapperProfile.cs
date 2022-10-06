using AutoMapper;
using DemoApp.Companies;
using DemoApp.Sites;

namespace DemoApp;

public class DemoAppApplicationAutoMapperProfile : Profile
{
    public DemoAppApplicationAutoMapperProfile()
    {
        CreateMap<Company, CompanyDto>();
        CreateMap<CreateCompanyDto, Company>();
        CreateMap<UpdateCompanyDto, Company>();


        CreateMap<Site, SiteDto>();
        CreateMap<CreateSiteDto, Site>();
        CreateMap<UpdateSiteDto, Site>();
    }
}
