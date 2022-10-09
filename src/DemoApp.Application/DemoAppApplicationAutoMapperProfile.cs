using AutoMapper;
using DemoApp.Companies;
using DemoApp.Companies.Childs;
using DemoApp.Sites;

namespace DemoApp;

public class DemoAppApplicationAutoMapperProfile : Profile
{
    public DemoAppApplicationAutoMapperProfile()
    {
        // Companies (+childs)
        CreateMap<Company, CompanyDto>();
        CreateMap<CreateCompanyDto, Company>();
        CreateMap<UpdateCompanyDto, Company>();
        CreateMap<Site, SiteOfCompanyDto>();
        CreateMap<SiteOfCreateCompanyDto, Site>();
        CreateMap<SiteOfUpdateCompanyDto, Site>();

        // Sites
        CreateMap<Site, SiteDto>();
        CreateMap<CreateSiteDto, Site>();
        CreateMap<UpdateSiteDto, Site>();
    }
}
