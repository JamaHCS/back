namespace Domain.Entities.Log
{
    public record LogSubject
    {
       public int Id { get; init; }
       public string Description { get; init; }
       public ICollection<LogEvent> LogEvents { get; init; } = new List<LogEvent>();
    }
}
