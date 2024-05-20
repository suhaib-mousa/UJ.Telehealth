using DevNAS.LiveCoaching.Common.Skills;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Telehealth.Skills;

public class TelehealthSkillLookupAppService : SkillLookupAppService, ITransientDependency
{
    private readonly SkillAppService _commonSkillAppService;

    public TelehealthSkillLookupAppService(SkillAppService commonSkillAppService)
    {
        _commonSkillAppService = commonSkillAppService;
    }
    public override async Task<List<SkillLookup>?> GetSkillLookups()
    {
        var subjects = await _commonSkillAppService.GetMains();
        var levels = await _commonSkillAppService.GetSubs();
        var subjectLookup = new SkillLookup("MainSpecialties", subjects.Select(l => l.Title).ToList());
        var levelLookup = new SkillLookup("Sub-Specialties", levels.Select(l => l.Title).ToList());
        return new List<SkillLookup>() {
            subjectLookup,
            levelLookup
        };
    }
}
