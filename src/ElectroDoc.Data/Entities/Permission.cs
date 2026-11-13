using System.Net;

namespace ElectroDoc.Data;

public class Permission
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<MembershipPermission> MembershipPermissions { get; set; } = [];
    public List<PermissionHistory> PermissionHistory { get; set; } = [];
}