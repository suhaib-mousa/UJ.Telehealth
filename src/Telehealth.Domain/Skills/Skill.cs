using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Telehealth.Skills;

public class MainSkill : Entity<Guid>
{
    public string? Title { get; set; }
    public int? order { get; set; }
}
public interface ISkillMainRepository : IRepository<MainSkill, Guid>
{

}
public class SubSkill : Entity<Guid>
{
    public string? Title { get; set; }
    public int? order { get; set; }
}
public interface ISkillSubRepository : IRepository<SubSkill, Guid>
{

}
public class Skill
{
    public MainSkill Main { get; set; }
    public SubSkill Sub { get; set; }
}
