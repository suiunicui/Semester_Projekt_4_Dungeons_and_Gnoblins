namespace GameEngine.Interfaces;

public interface IMapCreator
{ 
  public string FilePath { get; set; }
  public void GenerateMapLayoutFile();

}