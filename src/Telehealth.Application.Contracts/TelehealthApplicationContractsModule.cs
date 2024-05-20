﻿using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas.Host;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict;
using Volo.CmsKit;
using DevNAS.LiveCoaching;
using DevNAS.LiveCoaching.Public;
using DevNAS.LiveCoaching.Common;

namespace Telehealth;

[DependsOn(
    typeof(TelehealthDomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(SaasHostApplicationContractsModule),
    typeof(AbpAuditLoggingApplicationContractsModule),
    typeof(AbpOpenIddictProApplicationContractsModule),
    typeof(AbpAccountPublicApplicationContractsModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(LanguageManagementApplicationContractsModule),
    typeof(AbpGdprApplicationContractsModule),
    typeof(CmsKitProApplicationContractsModule),
    typeof(TextTemplateManagementApplicationContractsModule)
)]
[DependsOn(
    typeof(LiveCoachingCommonApplicationContractsModule),
    typeof(LiveCoachingPublicApplicationContractsModule),
    typeof(LiveCoachingApplicationContractsModule)
    )]
public class TelehealthApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        TelehealthDtoExtensions.Configure();
    }
}
