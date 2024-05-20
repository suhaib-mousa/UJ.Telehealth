using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Telehealth.Web.Public.Bundling;

public class TelehealthGlobalScriptContributer : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/assets/js/core/libs.min.js");
        context.Files.Add("/assets/js/plugins/slider-tabs.js");
        context.Files.Add("/assets/js/plugins/fslightbox.js");
        context.Files.Add("/assets/vendor/swiperSlider/swiper-bundle.min.js");
        context.Files.Add("/assets/vendor/lodash/lodash.min.js");
        context.Files.Add("/assets/js/iqonic-script/utility.min.js");
        context.Files.Add("/assets/js/iqonic-script/setting.min.js");
        context.Files.Add("/assets/js/iqonic-script/setting-init.js");
        context.Files.Add("/assets/js/core/external.min.js");
        context.Files.Add("/assets/js/kivicare.js");
        context.Files.Add("/assets/js/kivicare-advance.js");
        context.Files.Add("/assets/js/slider.js");
        context.Files.Add("/assets/js/scroll-text.js");
    }
}
