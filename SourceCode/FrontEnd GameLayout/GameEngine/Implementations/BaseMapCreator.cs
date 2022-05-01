using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class BaseMapCreator : IMapCreator
{
    public string FilePath { get; set; }
    public void GenerateMapLayoutFile()
    {
        throw new NotImplementedException();
    }
}