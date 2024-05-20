using Telehealth.Localization;
using Volo.Abp.Application.Services;

namespace Telehealth;

/* Inherit your application services from this class.
 */
public abstract class TelehealthAppService : ApplicationService
{
    protected TelehealthAppService()
    {
        LocalizationResource = typeof(TelehealthResource);
    }
}
