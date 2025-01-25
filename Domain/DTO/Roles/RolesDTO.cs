namespace Domain.DTO.Roles
{
    public class RoleWithPermissions
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<PermissionDTO> Permissions { get; set; } = new List<PermissionDTO>();
    }

    public class PermissionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

}
