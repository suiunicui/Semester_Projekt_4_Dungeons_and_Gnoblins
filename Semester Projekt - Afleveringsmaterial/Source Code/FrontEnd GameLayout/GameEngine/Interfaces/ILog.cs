namespace GameEngine.Interfaces;

public interface ILog
{
    Dictionary<string, string> LogEntry { get; }
    void RecordEvent(string key, string value);
    string GetRecord(string key);
}