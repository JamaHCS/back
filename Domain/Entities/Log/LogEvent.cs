namespace Domain.Entities.Log
{
    public record LogEvent
    {
        public int Id { get; init; }
        public string? Message { get; init; }
        public string? MessageTemplate { get; init; }
        public string? Level { get; init; }
        public DateTimeOffset? TimeStamp { get; init; }
        public string? Exception { get; init; }
        public string? Properties { get; init; }
        public string? User { get; init; }
        public int LogSubjectId { get; init; }
        public LogSubject LogSubject { get; init; }
    }
}
