using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telehealth.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Settings;
using Volo.Abp.ObjectMapping;
using Volo.Abp.SettingManagement;

namespace Telehealth.Doctors
{
    //[Authorize(TelehealthPermissions.Doctor.Default)]
    public class DoctorAppService : CrudAppService<IdentityUser, DoctorDto, Guid, GetListDoctorDto, CreateDoctorDto, UpdateDoctorDto>, IDoctorAppService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IIdentityUserAppService _identityUserAppService;
        private readonly ISettingManager _settingManager;
        private readonly IIdentityRoleRepository _identityRoleRepository;

        public DoctorAppService(IRepository<IdentityUser, Guid> repository, UserManager<IdentityUser> userManager,
            IIdentityUserAppService identityUserAppService
            , ISettingManager settingManager,
            IIdentityRoleRepository identityRoleRepository) : base(repository)
        {
            _userManager = userManager;
            _identityUserAppService = identityUserAppService;
            _settingManager = settingManager;
            _identityRoleRepository = identityRoleRepository;
            GetPolicyName = TelehealthPermissions.Doctor.Default;
            //GetListPolicyName = TelehealthPermissions.Doctor.Default;
            CreatePolicyName = TelehealthPermissions.Doctor.Create;
            UpdatePolicyName = TelehealthPermissions.Doctor.Edit;
            DeletePolicyName = TelehealthPermissions.Doctor.Delete;
        }
        protected override Task<IQueryable<IdentityUser>> CreateFilteredQueryAsync(GetListDoctorDto input)
        {
            return base.CreateFilteredQueryAsync(input);
        }
        public override async Task<PagedResultDto<DoctorDto>> GetListAsync(GetListDoctorDto input)
        {
            //var query = (await base.CreateFilteredQueryAsync(input));
            var role = await _identityRoleRepository.FindByNormalizedNameAsync("Doctor");
            var roleId = role.Id;
            var query =(await Repository.WithDetailsAsync(x => x.Roles)).Where(x=>x.Roles.Any(y=>y.RoleId==roleId));

            var totalCount = await AsyncExecuter.CountAsync(query);
            var doctors= new List<IdentityUser>();
            if (totalCount > 0)
            {
                query = ApplySorting(query, input);
                query = ApplyPaging(query, input);
                doctors = await AsyncExecuter.ToListAsync(query);
            }

            var doctorDtos = ObjectMapper.Map<List<IdentityUser>, List<DoctorDto>>(doctors);

            return new PagedResultDto<DoctorDto>(totalCount, doctorDtos);
        }

        public override async Task<DoctorDto> CreateAsync(CreateDoctorDto input)
        {
            await ChangeIdentityOptions();
            var identityUser2 = ObjectMapper.Map<CreateDoctorDto, IdentityUserCreateDto>(input);
            identityUser2.RoleNames = ["Doctor"];
            await _identityUserAppService.CreateAsync(identityUser2);
            return null;
        }

        public async Task ChangeIdentityOptions()
        {
            // Set IdentityOptions using ISettingManager
            await _settingManager.SetForCurrentTenantAsync(
                IdentitySettingNames.Password.RequireDigit,
                "false"
            );

            await _settingManager.SetForCurrentTenantAsync(
                IdentitySettingNames.Password.RequireLowercase,
                "false"
            );

            await _settingManager.SetForCurrentTenantAsync(
                IdentitySettingNames.Password.RequireNonAlphanumeric,
                "false"
            );

            await _settingManager.SetForCurrentTenantAsync(
                IdentitySettingNames.Password.RequireUppercase,
                "false"
            );

            await _settingManager.SetForCurrentTenantAsync(
                IdentitySettingNames.Password.RequiredUniqueChars,
                "0"
            );
            await _settingManager.SetForCurrentTenantAsync(
           IdentitySettingNames.Password.RequiredLength,
                "3"
                );

            // Adjust other settings as needed
        }
    }
}