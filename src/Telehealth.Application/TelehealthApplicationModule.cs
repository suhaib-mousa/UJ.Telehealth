using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Gdpr;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas.Host;
using Volo.CmsKit;
using DevNAS.LiveCoaching;
using DevNAS.LiveCoaching.Public;
using DevNAS.LiveCoaching.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DevNAS.LiveCoaching.Common.ReservationManagement.Reservations;
using Telehealth.Members;
using DevNAS.LiveCoaching.Common.ReservationManagement;
using Telehealth.Skills;
using DevNAS.LiveCoaching.Common.Skills;

namespace Telehealth;

[DependsOn(
    typeof(TelehealthDomainModule),
    typeof(TelehealthApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(SaasHostApplicationModule),
    typeof(AbpAuditLoggingApplicationModule),
    typeof(AbpOpenIddictProApplicationModule),
    typeof(AbpAccountPublicApplicationModule),
    typeof(AbpAccountAdminApplicationModule),
    typeof(LanguageManagementApplicationModule),
    typeof(AbpGdprApplicationModule),
    typeof(CmsKitProApplicationModule),
    typeof(TextTemplateManagementApplicationModule)
    )]
[DependsOn(
    typeof(LiveCoachingCommonApplicationModule),
    typeof(LiveCoachingPublicApplicationModule),
    typeof(LiveCoachingApplicationModule)
    )]
public class TelehealthApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<TelehealthApplicationModule>();
        });
        //Configure<IdentityOptions>(options =>
        //{
        //    options.Password.RequiredLength = 5;
        //});
        context.Services.Replace(
        ServiceDescriptor.Transient<IReservationMemberLookupAppService, Telehealth.Members.ReservationMembersAppService>()
        );
        context.Services.Replace(
        ServiceDescriptor.Transient<ISkillLookupAppService, TelehealthSkillLookupAppService>()
        );
    }


}
