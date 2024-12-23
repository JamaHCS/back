using Domain.Entities.Log;
using Microsoft.AspNetCore.Identity;


namespace Domain.Entities.Auth
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Deleted { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<LogEvent> Logs { get; set; } = new List<LogEvent>();
    }
}
