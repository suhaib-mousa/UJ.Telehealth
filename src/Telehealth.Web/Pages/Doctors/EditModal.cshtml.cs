using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Telehealth.Doctors;
using Volo.CmsKit.Admin.Blogs;

namespace Telehealth.Web.Pages.Doctors
{
    public class EditModalModel : TelehealthPageModel
    {
        

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public UpdateDoctorDto UpdateDoctorDto { get; set; }

        private readonly IDoctorAppService _doctorAppService;
        public EditModalModel(IDoctorAppService doctorAppService)
        {
           _doctorAppService = doctorAppService;
        }
        public async void OnGet()
        {
           var doctorDto=await _doctorAppService.GetAsync(Id);
            UpdateDoctorDto = ObjectMapper.Map<DoctorDto, UpdateDoctorDto>(doctorDto);
        }
        public async Task<IActionResult> OnPost()
        {
            await _doctorAppService.UpdateAsync(Id, UpdateDoctorDto);
            return NoContent();
        }
    }
}
