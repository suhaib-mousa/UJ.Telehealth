using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Telehealth.Skills;

public interface IMainSkillRepository : IRepository<MainSkill, Guid>
{
}

public interface ISubSkillRepository : IRepository<SubSkill, Guid>
{
}
