using System.Resources;
using System.Runtime.CompilerServices;
using GameEngineLibrary.Interfaces;

namespace GameEngineLibrary.MapCreator;

public class BaseMapCreator : IMapCreator
{
  public string FilePath { get; set; } = Environment.CurrentDirectory + @"\\MapLayout"; 
  public BaseMapCreator()
  {
    GenerateMapLayoutFile();
  }
  public void GenerateMapLayoutFile()
  {
    StreamWriter sw = new StreamWriter(FilePath);
    sw.WriteLine("-1, -1, -1, 1");
    sw.WriteLine("-1,0,2,-1");
    sw.WriteLine("1,3,-1,4");
    sw.WriteLine("-1,8,13,3");
    sw.WriteLine("6,3,18,-1");
    sw.WriteLine("-1,-1,5,7");
    sw.WriteLine("-1,-1,9,4");
    sw.WriteLine("8,-1,10,-1");
    sw.WriteLine("9,-1,-1,-1");
    sw.WriteLine("13,10,12,15");
    sw.WriteLine("11,-1,-1,-1");
    sw.WriteLine("4,-1,11,14");
    sw.WriteLine("-1,13,-1,-1");
    sw.WriteLine("-1,11,-1,16");
    sw.WriteLine("18,15,17,-1");
    sw.WriteLine("16,-1,-1,-1");
    sw.WriteLine("5,-1,16,19");
    sw.WriteLine("-1,18,20,-1");
    sw.WriteLine("19,-1,-1,-1");
    sw.Close();
  }
}