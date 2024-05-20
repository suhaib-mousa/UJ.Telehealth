using System.Threading.Tasks;

namespace Telehealth.Data;

public interface ITelehealthDbSchemaMigrator
{
    Task MigrateAsync();
}
