namespace Domain.DTO.Users
{
    public record GetUserDTO
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string MiddleName { get; init; }
        public string LastName { get; init; }
        public string MotherLastName { get; init; }
        public string Email {  get; init; }
        public DateTime DateOfBirth { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public Guid? CreatedBy { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public Guid? UpdatedBy { get; init; }
        public DateTime? LastLoginAt { get; init; }
        public string? DeletedBy { get; init; }
        public DateTime? DeletedAt { get; init; }
        public bool Deleted { get; init; }
        public string PhoneNumber { get; init; }
    }
}
