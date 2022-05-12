using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class Log : ILog
{
    public Dictionary<string, string> LogEntry { get; }

    public Log()
    {
        LogEntry = new Dictionary<string, string>();
    }
    public void RecordEvent(string key, string value)
    {
        string lowerKey = key.ToLower();
        LogEntry[lowerKey] = value;
    }

    public string GetRecord(string key)
    {
        string lowerKey = key.ToLower();
        return LogEntry[lowerKey];
    }
}