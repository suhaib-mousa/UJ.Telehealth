using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Telehealth.Web.Public.Bundling;

public class TelehealthGlobalStyleContributer : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/assets/css/core/libs.min.css");
        context.Files.Add("/assets/vendor/flaticon/css/flaticon.css");
        context.Files.Add("/assets/vendor/font-awesome/css/all.min.css");
        context.Files.Add("/assets/vendor/swiperSlider/swiper-bundle.min.css");
        context.Files.Add("/assets/css/kivicare.min.css");
        context.Files.Add("/assets/css/custom.min.css");
        context.Files.Add("/assets/css/rtl.min.css");
        context.Files.Add("/assets/css/customizer.min.css");
    }
}
