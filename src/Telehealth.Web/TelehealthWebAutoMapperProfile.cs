using AutoMapper;
using Telehealth.Doctors;

namespace Telehealth.Web;

public class TelehealthWebAutoMapperProfile : Profile
{
    public TelehealthWebAutoMapperProfile()
    {
        CreateMap<DoctorDto, UpdateDoctorDto>().ReverseMap();
    }
}
