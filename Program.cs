using ProjektLeg.Models;
using ProjektLeg;



using (var context = new MyDbContext())
{ 
    var DataHelper = new DAL();

    //var gamesave = new GameDTO();
    //gamesave.Username = "Luyen Vu";
    //gamesave.RoomID = 13;
    //gamesave.Health = 69;
    //gamesave.itemsID.Add(12);
    //gamesave.enemyID.Add(1);
    //gamesave.PuzzleID.Add(1);

    //DataHelper.SaveWholeGame(gamesave);


    //DataHelper.RemoveUser("Luyen Vu");


    //var save = new GameDTO();
    //save.SaveName = "Get This";
    //save.RoomID = 12;
    //save.Health = 22;
    //save.Username = "Luyen-Vu";


    //save.PuzzleID.Add(1);
    //save.PuzzleID.Add(3);
    //save.enemyID.Add(1);
    //save.enemyID.Add(5);
    //save.itemsID.Add(1);
    //save.itemsID.Add(3);

    //DataHelper.SaveWholeGame(save);

    //var save1 = new GameDTO();
    //save1.SaveName = "fuck";
    //save1.RoomID = 12;
    //save1.Health = 2;
    //save1.Username = "Luyen-Vu";

    //DataHelper.SaveWholeGame(save1);

    //var save2 = new GameDTO();
    //save2.SaveName = "OD";
    //save2.RoomID = 11;
    //save2.Health = 22;
    //save2.Username = "Luyen-Vu";

    //DataHelper.SaveWholeGame(save2);

    //var save = DataHelper.GetSingleGame("Luyen-Vu", "Get This");

    //Console.WriteLine(save.Username);
    //Console.WriteLine(save.RoomID);
    //Console.WriteLine(save.SaveName);
    //Console.WriteLine(save.Health);
    //Console.WriteLine(save.Armour_ID);
    //Console.WriteLine(save.Weapon_ID);
    //foreach(var i in save.itemsID)
    //{
    //    Console.WriteLine(i);
    //}
    //foreach (var i in save.enemyID)
    //{
    //    Console.WriteLine(i);
    //}
    //foreach (var i in save.PuzzleID)
    //{
    //    Console.WriteLine(i);
    //}

    //DataHelper.DeleteSingleSave("Luyen-Vu", "Get This");
}

