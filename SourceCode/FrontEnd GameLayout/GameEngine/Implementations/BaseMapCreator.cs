using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class BaseMapCreator : IMapCreator
{
  public string FilePath { get; set; } = Environment.CurrentDirectory + @"\\";
  public string EnemyFilePath { get; set; } = Environment.CurrentDirectory + @"\\EnemyFile";
  public string ItemFilePath { get; set; } = Environment.CurrentDirectory + @"ItemFile";
  public BaseMapCreator(string fileName)
  {
      FilePath += fileName;
      GenerateMapLayoutFile();
      GenerateEnemyLayoutFile();
      GenerateItemLayoutFile();
  }
  public void GenerateMapLayoutFile()
  { 
    StreamWriter sw = new StreamWriter(FilePath);
    sw.WriteLine("-1, -1, -1, 1");
    sw.WriteLine("-1,0,2,-1");
    sw.WriteLine("1,3,-1,4");
    sw.WriteLine("-1,7,12,2");
    sw.WriteLine("5,2,17,-1");
    sw.WriteLine("-1,-1,4,6");
    sw.WriteLine("-1,5,-1,-1");
    sw.WriteLine("-1,-1,8,3");
    sw.WriteLine("7,-1,9,-1");
    sw.WriteLine("8,-1,-1,10");
    sw.WriteLine("12,9,11,14");
    sw.WriteLine("10,-1,-1,-1");
    sw.WriteLine("3,-1,10,13");
    sw.WriteLine("-1,12,-1,-1");
    sw.WriteLine("-1,10,-1,15");
    sw.WriteLine("17,14,16,-1");
    sw.WriteLine("15,-1,-1,-1");
    sw.WriteLine("4,-1,15,18");
    sw.WriteLine("-1,17,19,-1");
    sw.WriteLine("18,-1,-1,-1");
    sw.Close();
  }

  public void GenerateEnemyLayoutFile()
  {
    // Room ID, HP, AC, DamageDiceSides, DamageDiceCount, ToHitBonus
    StreamWriter sw = new StreamWriter(EnemyFilePath);
<<<<<<< HEAD
    sw.WriteLine("2, 10, 12, 8, 1, 2");
    sw.WriteLine("5, 10, 12, 8, 1, 2");
    sw.WriteLine("12, 10, 12, 8, 1, 2");
    sw.WriteLine("16, 10, 12, 8, 1, 2");
    sw.WriteLine("18, 10, 12, 8, 1, 2");
=======
    sw.WriteLine("2, 10, 12, 8, 1, 2, Naked Gnoblin");
    sw.WriteLine("5, 10, 12, 8, 1, 2, Welp");
    sw.WriteLine("12, 10, 12, 8, 1, 2, Big Naked Gnoblin");
    sw.WriteLine("16, 10, 12, 8, 1, 2, Brute Gnoblin");
    sw.WriteLine("18, 20, 13, 10, 1, 2, Gnoblin King"); //boss
>>>>>>> FrontEnd
    sw.Close();
  }

  public void GenerateItemLayoutFile()
  {
    // Room Id, Item Type, DamageDiceSides, DamageDiceCount, BaseDamage, ToHitBonus
    StreamWriter sw = new StreamWriter(ItemFilePath);

    // Weapons
    sw.WriteLine("1 ,1 ,8 ,1 ,2 ,2");
<<<<<<< HEAD

    // Shields Room Id, Item Type, AC
    sw.WriteLine("2,2,1");
=======
    sw.WriteLine("13, 3, 12, 1, 3, 3");

    // Shields Room Id, Item Type, AC
    sw.WriteLine("2,2,2");
    sw.WriteLine("6,4,2");

>>>>>>> FrontEnd
    sw.Close();
  }

}