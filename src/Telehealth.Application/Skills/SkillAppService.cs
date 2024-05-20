using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Telehealth.Skills;

public class SkillAppService : ApplicationService, ITransientDependency
{
    public SkillAppService(ISubSkillRepository subskillRepository, IMainSkillRepository mainSkillRepository)
    {
        _subSkillRepository = subskillRepository;
        _mainSkillRepository = mainSkillRepository;
    }

    public ISubSkillRepository _subSkillRepository { get; }
    public IMainSkillRepository _mainSkillRepository { get; }
    public async Task<List<MainSkill>> GetMains()
    {
        var subjects = await _mainSkillRepository.GetListAsync();
        return subjects;
    }
    public async Task<MainSkill> CreateMain(string title)
    {
        var subject = await _mainSkillRepository.InsertAsync(new MainSkill { Title = title });
        return subject;
    }
    public async Task<List<SubSkill>> GetSubs()
    {
        var levels = await _subSkillRepository.GetListAsync();
        return levels;
    }
    public async Task<SubSkill> CreateSub(string title)
    {
        var level = await _subSkillRepository.InsertAsync(new SubSkill { Title = title });
        return level;
    }
    public async Task<bool> DeleteMain(string title)
    {
        await _mainSkillRepository.DeleteAsync(x => x.Title == title);
        return true;
    }
    public async Task<bool> DeleteSub(string title)
    {
        await _subSkillRepository.DeleteAsync(x => x.Title == title);
        return true;
    }

    public async Task ChangeMainsOrder(List<MainSkill> subjects)
    {
        foreach (var subject in subjects)
        {
            var entity = await _mainSkillRepository.GetAsync(subject.Id);
            entity.order = subject.order;
            await _mainSkillRepository.UpdateAsync(entity);
        }
    }

    public async Task ChangeSubsOrder(List<SubSkill> levels)
    {
        foreach (var level in levels)
        {
            var entity = await _subSkillRepository.GetAsync(level.Id);
            entity.order = level.order;
            await _subSkillRepository.UpdateAsync(entity);
        }
    }
}
