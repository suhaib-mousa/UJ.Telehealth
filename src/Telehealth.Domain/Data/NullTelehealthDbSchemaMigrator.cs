using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Telehealth.Data;

/* This is used if database provider does't define
 * ITelehealthDbSchemaMigrator implementation.
 */
public class NullTelehealthDbSchemaMigrator : ITelehealthDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
