using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Telehealth.Web;

[Dependency(ReplaceServices = true)]
public class TelehealthBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Telehealth";
}
