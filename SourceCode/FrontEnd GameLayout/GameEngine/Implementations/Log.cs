using GameEngine.Interfaces;
using System.Collections;

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

    public static ILog operator +(ILog a, Log b)
    {
        foreach (var entry in b.LogEntry)
        {
            a.RecordEvent(entry.Key, entry.Value);
        }

        return a;
    }
}