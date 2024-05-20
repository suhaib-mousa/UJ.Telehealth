using Telehealth.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Telehealth.Permissions;

public class TelehealthPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TelehealthPermissions.GroupName);

        myGroup.AddPermission(TelehealthPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(TelehealthPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        var DoctorGroup = context.AddGroup(TelehealthPermissions.DoctorGroup, L("Permission:Doctor"));
        var DoctorsPermission = DoctorGroup.AddPermission(TelehealthPermissions.Doctor.Default, L("Permission:Doctors"));
        DoctorsPermission.AddChild(TelehealthPermissions.Doctor.Create, L("Permission:Doctors.Create"));
        DoctorsPermission.AddChild(TelehealthPermissions.Doctor.Edit, L("Permission:Doctors.Edit"));
        DoctorsPermission.AddChild(TelehealthPermissions.Doctor.Delete, L("Permission:Doctors.Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(TelehealthPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TelehealthResource>(name);
    }
}
