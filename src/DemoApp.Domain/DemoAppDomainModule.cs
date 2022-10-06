using Volo.Abp.Modularity;

namespace DemoApp;

[DependsOn(
    typeof(DemoAppDomainSharedModule)
)]
public class DemoAppDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
