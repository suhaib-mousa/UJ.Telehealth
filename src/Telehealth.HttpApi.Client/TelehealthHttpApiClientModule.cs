using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Abp.SettingManagement;
using Volo.Saas.Host;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Gdpr;
using Volo.CmsKit;
using DevNAS.LiveCoaching;
using DevNAS.LiveCoaching.Public;
using DevNAS.LiveCoaching.Common;

namespace Telehealth;

[DependsOn(
    typeof(TelehealthApplicationContractsModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule),
    typeof(SaasHostHttpApiClientModule),
    typeof(AbpAuditLoggingHttpApiClientModule),
    typeof(AbpOpenIddictProHttpApiClientModule),
    typeof(AbpAccountAdminHttpApiClientModule),
    typeof(AbpAccountPublicHttpApiClientModule),
    typeof(LanguageManagementHttpApiClientModule),
    typeof(AbpGdprHttpApiClientModule),
    typeof(CmsKitProHttpApiClientModule),
    typeof(TextTemplateManagementHttpApiClientModule)
)]
[DependsOn(
    typeof(LiveCoachingCommonHttpApiClientModule),
    typeof(LiveCoachingPublicHttpApiClientModule),
    typeof(LiveCoachingHttpApiClientModule)
    )]
public class TelehealthHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(TelehealthApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TelehealthHttpApiClientModule>();
        });
    }
}
