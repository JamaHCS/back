namespace Domain.DTO.Roles
{
    public class RoleWithPermissions
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<PermissionDTO> Permissions { get; set; } = new List<PermissionDTO>();
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public Guid? createdBy { get; set; }
        public Guid? updatedBy { get; set; }
    }

    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public Guid? createdBy { get; set; }
        public Guid? updatedBy { get; set; }
    }

    public class PermissionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

}
