using AutoMapper;
using Telehealth.Doctors;

namespace Telehealth;

public class TelehealthApplicationAutoMapperProfile : Profile
{
    public TelehealthApplicationAutoMapperProfile()
    {
        CreateMap<Volo.Abp.Identity.IdentityUser, DoctorDto>().ReverseMap();
        CreateMap< CreateDoctorDto, Volo.Abp.Identity.IdentityUser>();
        CreateMap< CreateDoctorDto, Volo.Abp.Identity.IdentityUserCreateDto>();
        CreateMap< UpdateDoctorDto, Volo.Abp.Identity.IdentityUser>();
    }
}
