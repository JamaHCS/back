namespace Domain.DTO.Auth
{
    public record TokenResponse
    {
        public string Token { get; init; }
        public Guid UserId { get; init; }
    }
}
