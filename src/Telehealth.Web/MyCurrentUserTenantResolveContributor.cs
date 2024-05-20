using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace Telehealth.Web;

public class MyCurrentUserTenantResolveContributor : TenantResolveContributorBase
{
    public const string ContributorName = "CurrentUser";

    public override string Name => ContributorName;

    public override Task ResolveAsync(ITenantResolveContext context)
    {
        var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

        context.Handled = true;
        context.TenantIdOrName = "Telehealth";
        

        return Task.CompletedTask;
    }
}
