using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Telehealth.Data;

public class BunnySettingsDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private const string PublicBunnyStorage = "StorageManagement.Bunny.Public";
    private const string PublicZoneName = PublicBunnyStorage + ".ZoneName";
    private const string PublicZoneApiAccessKey = PublicBunnyStorage + ".ApiAccessKey";
    private const string PublicPullZone = PublicBunnyStorage + ".PullZone";
    private const string PublicZoneSecurityToken = PublicBunnyStorage + ".SecurityToken";
    private const string AccountApiAccessKey = "StorageManagement.Bunny.AccountApiAccessKey";


    private const string PrivateBunnyStorage = "StorageManagement.Bunny.Private";
    private const string PrivateZoneName = PrivateBunnyStorage + ".ZoneName";
    private const string PrivateZoneApiAccessKey = PrivateBunnyStorage + ".ApiAccessKey";
    private const string PrivatePullZone = PrivateBunnyStorage + ".PullZone";
    private const string PrivateZoneSecurityToken = PrivateBunnyStorage + ".SecurityToken";


    private readonly ISettingProvider _settingProvider;
    private readonly ISettingManager _settingManager;
    private readonly ISettingRepository _settingRepository;

    public BunnySettingsDataSeedContributor(ISettingProvider settingProvider, ISettingManager settingManager, ISettingRepository settingRepository)
    {
        _settingProvider = settingProvider;
        _settingManager = settingManager;
        _settingRepository = settingRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {

        bool isExist = ((await _settingRepository
            .GetListAsync()).Where(e => e.Name == PublicZoneName).Count()) > 0;

        if (!isExist)
        {
            await _settingRepository
                .InsertAsync(new(Guid.NewGuid(), PublicZoneName, "devnaslms", "T", context.TenantId.ToString()));
            await _settingRepository
                .InsertAsync(new(Guid.NewGuid(), PublicPullZone, "https://cdn.playnaas.com", "T", context.TenantId.ToString()));
            await _settingRepository
                .InsertAsync(new(Guid.NewGuid(), PublicZoneApiAccessKey, "232f5cf3-ab22-4bf9-b1cff5125b82-af9b-42b6", "T", context.TenantId.ToString()));
        }

        bool isApiAccessKeyExists = ((await _settingRepository
              .GetListAsync()).Where(e => e.Name == AccountApiAccessKey).Count()) > 0;

        if (!isApiAccessKeyExists)
        {
            await _settingRepository
                .InsertAsync(new(Guid.NewGuid(), AccountApiAccessKey, "61c2c649-c53f-40ec-a42d-dda9ab4f88dc6886b5bb-856d-4f23-b706-3cf6d3ec8a9b", "T", context.TenantId.ToString()));
        }


        bool isPrivateStorageExist = ((await _settingRepository
                .GetListAsync()).Where(e => e.Name == PrivateZoneName).Count()) > 0;

        if (!isPrivateStorageExist)
        {
            await _settingRepository
                .InsertAsync(new(Guid.NewGuid(), PrivateZoneName, "devnaslms-private", "T", context.TenantId.ToString()));
            await _settingRepository
                .InsertAsync(new(Guid.NewGuid(), PrivatePullZone, "https://privatecdn.playnaas.com", "T", context.TenantId.ToString()));
            await _settingRepository
                .InsertAsync(new(Guid.NewGuid(), PrivateZoneApiAccessKey, "813399b3-f600-4bd0-ae5790efd63b-fa4d-4992", "T", context.TenantId.ToString()));
            await _settingRepository
                 .InsertAsync(new(Guid.NewGuid(), PrivateZoneSecurityToken, "256ca9b9-b8f3-4a3c-8112-b1374bc38428", "T", context.TenantId.ToString()));

        }
    }
}
