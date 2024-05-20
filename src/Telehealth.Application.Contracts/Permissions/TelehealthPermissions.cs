namespace Telehealth.Permissions;

public static class TelehealthPermissions
{
    public const string GroupName = "Telehealth";

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = DashboardGroup + ".Tenant";
    }
    public const string DoctorGroup = "Doctor";
    public static class Doctor
    {
        public const string Default = DoctorGroup + ".Doctors";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
