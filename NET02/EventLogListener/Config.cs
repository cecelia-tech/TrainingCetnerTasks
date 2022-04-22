namespace EventLogListener
{
    public class Config
    {
        public string? SourceName { get; set; }
        public string? LogName { get; set; }
        public int LogLevel { get; set; } = 0;
    }
}
