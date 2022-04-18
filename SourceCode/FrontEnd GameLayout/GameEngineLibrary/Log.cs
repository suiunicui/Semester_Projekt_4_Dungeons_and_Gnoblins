namespace GameEngineLibrary
{
  public class Log
  {
    private Dictionary<string, string> _logEntry;

    public Log()
    {
      _logEntry = new Dictionary<string, string>();
    }

    public void recordEvent(string key, string value)
    {
      _logEntry[key] = value;
    }

    public string GetEventRecord(string key)
    {
      return _logEntry[key];
    }
  }
}
