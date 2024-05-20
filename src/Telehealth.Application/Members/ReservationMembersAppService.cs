using DevNAS.LiveCoaching.Common.ReservationManagement.Reservations;
using DevNAS.LiveCoaching.Common.ReservationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Repositories;

namespace Telehealth.Members;

public class ReservationMembersAppService : ReservationMemberLookupAppService, ITransientDependency
{
    private readonly IRepository<IdentityUser, Guid> _identityUserRepository;

    public ReservationMembersAppService(IRepository<IdentityUser, Guid> identityUserRepository)
    {
        _identityUserRepository = identityUserRepository;
    }

    public override async Task<PagedResultDto<MemberLookup>> GetMemberPagedListAsync(MemberLookupPagedResultRequestDto input)
    {
        
        var query = (await _identityUserRepository.WithDetailsAsync(x => x.Roles));
        query = query
            .Where(u => u.Roles.Count == 0)
       .WhereIf(!string.IsNullOrEmpty(input.Name), m => (m.Name + " " + m.Surname).Contains(input.Name));
        var totalCount = await AsyncExecuter.CountAsync(query);

        var result = query
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .Select(member => new MemberLookup
            {
                EntityId = member.Id,
                EntityName = member.Name + " " + member.Surname,
            })
            .ToList();


        return new PagedResultDto<MemberLookup>(
            totalCount,
            result
        );
    }
}
