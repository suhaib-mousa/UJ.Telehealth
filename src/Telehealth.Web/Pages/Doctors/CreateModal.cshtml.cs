using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Telehealth.Doctors;

namespace Telehealth.Web.Pages.Doctors
{
    public class CreateModalModel : TelehealthPageModel
    {
        private readonly IDoctorAppService _doctorAppService;

        [BindProperty]
        public CreateDoctorDto CreateDoctorDto { get; set; }
        public CreateModalModel(IDoctorAppService doctorAppService)
        {
            _doctorAppService = doctorAppService;
        }
        public void OnGet()
        {
            CreateDoctorDto = new CreateDoctorDto();
        }
        public async Task<IActionResult> OnPost()
        {
           await _doctorAppService.CreateAsync(CreateDoctorDto);
            return NoContent();
        }
    }
}
