using Volo.Abp.Modularity;

namespace DemoApp;

[DependsOn(
    typeof(DemoAppDomainSharedModule)
)]
public class DemoAppApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        DemoAppDtoExtensions.Configure();
    }
}
