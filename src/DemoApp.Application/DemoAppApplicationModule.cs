using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace DemoApp;

[DependsOn(
    typeof(DemoAppDomainModule),
    typeof(DemoAppApplicationContractsModule),
    typeof(AbpAutoMapperModule)
    )]
public class DemoAppApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<DemoAppApplicationModule>();
        });
    }
}
