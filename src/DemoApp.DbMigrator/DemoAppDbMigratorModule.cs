using DemoApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DemoApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DemoAppEntityFrameworkCoreModule),
    typeof(DemoAppApplicationContractsModule)
    )]
public class DemoAppDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
