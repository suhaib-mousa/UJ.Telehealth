using System.Threading.Tasks;
using Telehealth.Localization;
using Telehealth.Permissions;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.OpenIddict.Pro.Web.Menus;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.CmsKit.Pro.Public.Web.Menus;
using Volo.Saas.Host.Navigation;

namespace Telehealth.Public.Web.Menus;

public class TelehealthPublicMenuContributor : IMenuContributor
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

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                TelehealthPublicMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                TelehealthPublicMenus.Home,
                l["Doctors"],
                "~/LiveCoaching/Coaches",
                icon: "fa fa-user-md",
                order: 2
            )
        );
        context.Menu.AddItem(
    new ApplicationMenuItem(
        TelehealthPublicMenus.Home,
        l["AboutUs"],
        "~/AboutUs",
        icon: "fa fa-info",
        order: 3
    )
);

                context.Menu.AddItem(
    new ApplicationMenuItem(
        TelehealthPublicMenus.Home,
        l["ContactUs"],
        "~/ContactUs",
        icon: "fa fa-phone",
        order: 4
    )
);

        return Task.CompletedTask;
    }
}
