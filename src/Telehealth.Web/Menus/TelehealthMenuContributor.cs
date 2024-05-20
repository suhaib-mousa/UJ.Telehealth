using System.Threading.Tasks;
using Telehealth.Localization;
using Telehealth.Permissions;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.OpenIddict.Pro.Web.Menus;
using Volo.Abp.UI.Navigation;
using Volo.CmsKit.Pro.Admin.Web.Menus;
using Volo.Saas.Host.Navigation;
using Volo.Abp.Users;
using Microsoft.Extensions.DependencyInjection;
using DevNAS.LiveCoaching.Permissions;

namespace Telehealth.Web.Menus;

public class TelehealthMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<TelehealthResource>();
        var _currrentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                TelehealthMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        //HostDashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                TelehealthMenus.HostDashboard,
                l["Menu:Dashboard"],
                "~/HostDashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(TelehealthPermissions.Dashboard.Host)
        );

        //TenantDashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                TelehealthMenus.TenantDashboard,
                l["Menu:Dashboard"],
                "~/Dashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(TelehealthPermissions.Dashboard.Tenant)
        );

        context.Menu.SetSubItemOrder(SaasHostMenuNames.GroupName, 3);
        //CMS
        context.Menu.SetSubItemOrder(CmsKitProAdminMenus.GroupName, 4);

        if (_currrentUser.IsInRole("admin"))
        {
            context.Menu.AddItem(
           new ApplicationMenuItem(
               TelehealthMenus.TenantDashboard,
               l["Doctors"],
               "~/Doctors",
               icon: "fa fa-user-md",
               order: 5
           )
       );

        } else if (_currrentUser.IsInRole("Doctor"))
        {
            context.Menu.Items.Insert(5,
        new ApplicationMenuItem(
                "AdminMenu.LiveCoaching",
                l["Dashboard"],
                icon: "fa fa-video-camera",
                url: $"/LiveCoaching?Id={_currrentUser.Id}&Name={_currrentUser.Name + ' ' + _currrentUser.SurName}",
                requiredPermissionName: LiveCoachingPermissions.Coach.Dashboard
            )
        );
        }
        

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        //Administration->OpenIddict
        administration.SetSubItemOrder(OpenIddictProMenus.GroupName, 2);

        //Administration->Language Management
        administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 3);

        //Administration->Text Template Management
        administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 4);

        //Administration->Audit Logs
        administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 5);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 6);

        return Task.CompletedTask;
    }
}
