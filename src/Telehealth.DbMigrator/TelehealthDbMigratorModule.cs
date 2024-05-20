using Telehealth.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Telehealth.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TelehealthEntityFrameworkCoreModule),
    typeof(TelehealthApplicationContractsModule)
)]
public class TelehealthDbMigratorModule : AbpModule
{

}
