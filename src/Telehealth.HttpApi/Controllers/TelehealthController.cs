using Telehealth.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Telehealth.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TelehealthController : AbpControllerBase
{
    protected TelehealthController()
    {
        LocalizationResource = typeof(TelehealthResource);
    }
}
