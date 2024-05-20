using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telehealth.Doctors;

namespace Telehealth.Public.Web.Pages
{
    public class AboutUsModel : PageModel
    {
        public IReadOnlyList<DoctorDto> DoctorsList { get; set; }
        private readonly IDoctorAppService _doctorAppService;
        public AboutUsModel(IDoctorAppService doctorAppService)
        {
            _doctorAppService = doctorAppService;
        }
        public async Task OnGet()
        {
            var doctors = await _doctorAppService.GetListAsync(new GetListDoctorDto());
            DoctorsList = doctors.Items;
        }

    }
}
