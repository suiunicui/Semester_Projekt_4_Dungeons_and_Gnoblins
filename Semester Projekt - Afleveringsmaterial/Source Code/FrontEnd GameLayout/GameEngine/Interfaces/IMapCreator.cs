namespace GameEngine.Interfaces;

public interface IMapCreator
{ 
  public string FilePath { get; set; }
  public string EnemyFilePath { get; set; }
  public string ItemFilePath { get; set; }
  public void GenerateMapLayoutFile();
}