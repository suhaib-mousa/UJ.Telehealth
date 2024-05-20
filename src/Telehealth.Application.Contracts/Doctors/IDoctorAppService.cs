using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Telehealth.Doctors
{
    public interface IDoctorAppService : ICrudAppService<DoctorDto,Guid, GetListDoctorDto, CreateDoctorDto,UpdateDoctorDto>
    {
        //public Task<PagedResultDto<DoctorDto>> GetIdentityDoctorLookupAsync();
    }
}
