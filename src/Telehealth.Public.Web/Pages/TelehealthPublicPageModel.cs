using Telehealth.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Telehealth.Web.Public.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class TelehealthPublicPageModel : AbpPageModel
{
    protected TelehealthPublicPageModel()
    {
        LocalizationResourceType = typeof(TelehealthResource);
    }
}
