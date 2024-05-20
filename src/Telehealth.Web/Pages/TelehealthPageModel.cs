using Telehealth.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Telehealth.Web.Pages;

public abstract class TelehealthPageModel : AbpPageModel
{
    protected TelehealthPageModel()
    {
        LocalizationResourceType = typeof(TelehealthResource);
    }
}
