using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektLeg.Models;

namespace ProjektLeg
{
    public class DAL
    {
        //MVP Save
        public void SaveGame(Save save)
        {
            var context = new MyDbContext();

            context.Add(save);

            context.SaveChanges();

        }

        //MVP Get
        public Save GetSaveByID(int SaveId)
        {
            var Context = new MyDbContext();

            var saves = Context.Saves.ToList();

            foreach (var save in saves)
            {
                if (save.SaveID == SaveId)
                    return save;
            }

            return null;

        }

        //Get list of savenames for user
        public List<string> getSaveNamesForUser(string username)
        {
            var context = new MyDbContext();
            List<string> SaveNames = new List<string>();

            //Finde brugeres saves
            var userSaves = context.Saves
                .Where(x => x.name == username).ToList();

            foreach(var s in userSaves)
            {
                SaveNames.Add(s.SaveName);
            }

            return SaveNames;
        }

        //Get single Save by name and username
        public GameDTO GetSingleGame(string username, string savename)
        {
            var context = new MyDbContext();

            //Finde brugeres saves
            var userSaves = context.Saves
                .Where(x => x.name == username).ToList();

            //Find korrekt save med navn
            var save = userSaves
                .First(x => (x.SaveName == savename) && (x.name == username));

            GameDTO ToReturn = new GameDTO();

            ToReturn.Username = save.name;
            ToReturn.RoomID = save.RoomID;
            ToReturn.SaveName = save.SaveName;
            ToReturn.Health = save.Health;
            ToReturn.Weapon_ID = save.Weapon_ID;
            ToReturn.Armour_ID = save.Armour_ID;

            var inv = context.Items.Where(s => s.SaveID == save.SaveID).ToList();
            var enemies = context.Enemies.Where(s => s.SaveID == save.SaveID).ToList();
            var puzzle = context.Puzzles.Where(s => s.Save_ID == save.SaveID).ToList();

            foreach (var i in inv)
            {
                ToReturn.itemsID.Add(i.ItemID);
            }

            foreach (var p in puzzle)
            {
                ToReturn.PuzzleID.Add(p.Puzzles_ID);
            }

            foreach (var e in enemies)
            {
                ToReturn.enemyID.Add(e.EnemyID);
            }

            return ToReturn;

        }

        //Get user to confirm password
        public User GetUserByUserName(string username)
        {
            var Context = new MyDbContext();

            var user = Context.Users.First(x => x.Username == username);

            if (user == null)
                return null;
            else
                return user;
        }

        //Create user
        public void CreateUser(string username, string password)
        {
            var context = new MyDbContext();

            User user = new User();

            user.Username = username;
            user.Password = password;

            context.Users.Add(user);

            context.SaveChanges();
        }

        
        //Remove a user with saves
        public void RemoveUser(string username)
        {
            var context = new MyDbContext();

            var user = context.Users.First(x => x.Username == username);
                     
            //var saves = user.Saves.ToList();

            var saves = context.Saves.Where(x => x.name == username).ToList();

            foreach (Save s in saves)
            {
                var id = s.SaveID;
                var inv = context.Items.Where(s => s.SaveID == id).ToList();
                var enemies = context.Enemies.Where(s => s.SaveID == id).ToList();
                var puzzle = context.Puzzles.Where(s => s.Save_ID == id).ToList();

                foreach (var i in inv)
                {
                    
                    context.Remove(i);
                }

                foreach(var p in puzzle)
                {
                    context.Remove(p);
                }
                
                foreach(var e in enemies)
                {
                    context.Remove(e);
                }
                

            }
            context.Remove(user);

            foreach (var s in saves)
            {
                context.Remove(s);
            }

            context.SaveChanges();
        }



        //Delete a single save with savename and username
        public void DeleteSingleSave(string username, string savename)
        {
            var context = new MyDbContext();

            //Finde brugeres saves
            var userSaves = context.Saves
                .Where(x => x.name == username).ToList();

            //Find korrekt save med navn
            var toDelete = userSaves
                .First(x => (x.SaveName == savename) && (x.name == username));

            //Vælg det Save som slettes
            //var toDelete = userSaves.First(s => s.SaveID == saveId);


            //Find de tilhørende Items, enemies og puzzles
            var inv = context.Items
                .Where(s => s.SaveID == toDelete.SaveID).ToList();

            var enemies = context.Enemies
                .Where(s => s.SaveID == toDelete.SaveID).ToList();

            var puzzle = context.Puzzles
                .Where(s => s.Save_ID == toDelete.SaveID).ToList();

            //Remove
            foreach (var i in inv)
            {

                context.Remove(i);
            }

            foreach (var p in puzzle)
            {
                context.Remove(p);
            }

            foreach (var e in enemies)
            {
                context.Remove(e);
            }


            context.Remove(toDelete);

            context.SaveChanges();
        }

        //Save a full game
        public void SaveWholeGame(GameDTO game)
        {
            var context = new MyDbContext();

            var user = context.Users.First(x => x.Username == game.Username);

            var save = new Save();

            save.RoomID = game.RoomID;
            save.Health = game.Health;
            save.Armour_ID = game.Armour_ID;
            save.Weapon_ID = game.Weapon_ID;
            save.name = game.Username;
            save.SaveName = game.SaveName;

            context.Add(save);
            context.SaveChanges();

            //user.Saves.Add(save);

            foreach (var i in game.itemsID)
            {
                var item = new Inventory_Items();
                item.SaveID = save.SaveID;
                item.ItemID = i;
                context.Add(item);
                //save.Save_Inventory_Items.Add(item);
                context.SaveChanges();
            }

            foreach(var i in game.enemyID)
            {
                var enemy = new Enemies_killed();
                enemy.SaveID = save.SaveID;
                enemy.EnemyID = i;
                context.Add(enemy);
               // save.Save_Enemies_killed.Add(enemy);
                context.SaveChanges();
            }

            foreach(var i in game.PuzzleID)
            {
                var puzzle = new Puzzles();
                puzzle.Save_ID = save.SaveID;
                puzzle.Puzzles_ID = i;
                context.Add(puzzle);
               // save.Save_Puzzles.Add(puzzle);
                context.SaveChanges();
            }

            

        }
    }
}
