using Domain.Entities.Global;

namespace Domain.Entities.Roles
{
    public class Permission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
