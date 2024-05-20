using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Telehealth.Doctors;

namespace Telehealth.Web.Public.Pages;

public class IndexModel : TelehealthPublicPageModel
{
    public IReadOnlyList<DoctorDto> DoctorsList { get; set; }
    private readonly IDoctorAppService _doctorAppService;
    public IndexModel(IDoctorAppService doctorAppService)
    {
       _doctorAppService = doctorAppService;
    }
    public async Task OnGet()
    {
        var doctors = await _doctorAppService.GetListAsync(new GetListDoctorDto());
        DoctorsList = doctors.Items;
    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
