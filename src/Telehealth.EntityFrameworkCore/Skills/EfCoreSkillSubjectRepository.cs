using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telehealth.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Telehealth.Skills;

public class EfCoreMainSkillRepository : EfCoreRepository<TelehealthDbContext, MainSkill, Guid>, IMainSkillRepository
{
    public EfCoreMainSkillRepository(IDbContextProvider<TelehealthDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}

public class EfCoreSubSkillRepository : EfCoreRepository<TelehealthDbContext, SubSkill, Guid>, ISubSkillRepository
{
    public EfCoreSubSkillRepository(IDbContextProvider<TelehealthDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}