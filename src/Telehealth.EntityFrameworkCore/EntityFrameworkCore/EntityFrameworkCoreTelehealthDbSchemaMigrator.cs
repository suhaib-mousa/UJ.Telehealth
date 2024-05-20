using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Telehealth.Data;
using Volo.Abp.DependencyInjection;

namespace Telehealth.EntityFrameworkCore;

public class EntityFrameworkCoreTelehealthDbSchemaMigrator
    : ITelehealthDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTelehealthDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the TelehealthDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TelehealthDbContext>()
            .Database
            .MigrateAsync();
    }
}
