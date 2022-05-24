using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend_API.db;
using Backend_API.Models;
using Backend_API.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Backend_API.DAL
{
    public class DAL
    {
        private readonly DaG_db _context;

        public DAL(DaG_db context)
        {
            _context = context;

        }

        #region Nye DAL funktioner til udvidet



        //Remove a user with saves
        public void RemoveUser(string username)
        {
            var user = _context.Users.First(x => x.Username == username);

            //var saves = user.Saves.ToList();

            var saves = _context.Saves.Where(x => x.Username == username).ToList();

            foreach (Save s in saves)
            {
                var id = s.ID;
                var inv = _context.Items.Where(s => s.SaveID == id).ToList();
                var enemies = _context.Enemies.Where(s => s.SaveID == id).ToList();
                var puzzle = _context.Puzzles.Where(s => s.Save_ID == id).ToList();
                var rooms = _context.VisitedRooms.Where(s => s.SaveId == id).ToList();

                foreach (var room in rooms)
                {
                    _context.Remove(room);
                }

                foreach (var i in inv)
                {

                    _context.Remove(i);
                }

                foreach (var p in puzzle)
                {
                    _context.Remove(p);
                }

                foreach (var e in enemies)
                {
                    _context.Remove(e);
                }


            }
            _context.Remove(user);

            foreach (var s in saves)
            {
                _context.Remove(s);
            }

            _context.SaveChanges();
        }

        //Delete a single save with savename and username
        public async Task DeleteSingleSave(int saveId)
        {

            //Finde brugeres saves
            //var userSaves = _context.Saves
            //    .Where(x => x.Username == username).ToList();

            //Find korrekt save med navn
            var toDelete = _context.Saves
                .First(x => x.ID == saveId);


            //Find de tilhørende Items, enemies og puzzles
            var inv = _context.Items
                .Where(s => s.SaveID == toDelete.ID).ToList();

            var enemies = _context.Enemies
                .Where(s => s.SaveID == toDelete.ID).ToList();

            var puzzle = _context.Puzzles
                .Where(s => s.Save_ID == toDelete.ID).ToList();

            var room = _context.VisitedRooms
                .Where(s => s.SaveId == toDelete.ID).ToList();

            //Remove
            foreach (var r in room)
            {

                _context.VisitedRooms.Remove(r);
            }

            foreach (var i in inv)
            {

                _context.Items.Remove(i);
            }

            foreach (var p in puzzle)
            {
                _context.Puzzles.Remove(p);
            }

            foreach (var e in enemies)
            {
                _context.Enemies.Remove(e);
            }


            _context.Saves.Remove(toDelete);

            //_context.SaveChanges();
        }

        //Save a full game 
        public void SaveWholeGame(SaveDTO game)
        {
            var user = _context.Users.First(x => x.Username == game.Username);

            var save = new Save();

            save.RoomID = game.RoomID;
            save.Health = game.Health;
            save.Armour_ID = game.ShieldId;
            save.Weapon_ID = game.WeaponId;
            save.Username = game.Username;
            save.SaveName = game.SaveName;

            _context.Add(save);
            _context.SaveChanges();

            //user.Saves.Add(save);

            foreach (var i in game.Inventory)
            {
                var item = new Inventory_Items();
                item.SaveID = save.ID;
                item.ItemID = i;
                _context.Add(item);
                _context.SaveChanges();
            }

            foreach (var i in game.SlainEnemies)
            {
                var enemy = new Enemies_killed();
                enemy.SaveID = save.ID;
                enemy.EnemyID = i;
                _context.Add(enemy);
                // save.Save_Enemies_killed.Add(enemy);
                _context.SaveChanges();
            }

            foreach (var i in game.PuzzleID)
            {
                var puzzle = new Puzzles();
                puzzle.Save_ID = save.ID;
                puzzle.Puzzles_ID = i;
                _context.Add(puzzle);
                // save.Save_Puzzles.Add(puzzle);
                _context.SaveChanges();
            }

            foreach (var r in game.VisitedRooms)
            {
                var room = new VisitedRooms();
                room.SaveId = save.ID;
                room.VistedRoomId = r;
                _context.Add(room);
                // save.Save_Puzzles.Add(puzzle);
                _context.SaveChanges();
            }
        }
        #endregion
        public async Task<ActionResult<User>> GetUser(string username)
        {
            var user = await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<ActionResult<User>> RegisterUser(User user)
        {
            _context.Users.Add(user);

            _context.Saves.AddRange(
                new Save { RoomID = 0, SaveName = "NewGame1", Username = user.Username, Health = 10 },
                new Save { RoomID = 0, SaveName = "NewGame2", Username = user.Username, Health = 10 },
                new Save { RoomID = 0, SaveName = "NewGame3", Username = user.Username, Health = 10 },
                new Save { RoomID = 0, SaveName = "NewGame4", Username = user.Username, Health = 10 },
                new Save { RoomID = 0, SaveName = "NewGame5", Username = user.Username, Health = 10 });

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<ActionResult<SaveDTO>> SaveGame(SaveDTO game)
        {
           
            Save oldSave = _context.Saves.Where(i => i.ID == game.ID).FirstOrDefault();

            var inv = _context.Items
                .Where(s => s.SaveID == oldSave.ID).ToList();

            var enemies = _context.Enemies
                .Where(s => s.SaveID == oldSave.ID).ToList();

            var puzzle = _context.Puzzles
                .Where(s => s.Save_ID == oldSave.ID).ToList();

            var room = _context.VisitedRooms
                .Where(s => s.SaveId == oldSave.ID).ToList();

            //Remove
            foreach (var r in room)
            {

                _context.VisitedRooms.Remove(r);
            }

            foreach (var i in inv)
            {

                _context.Items.Remove(i);
            }

            foreach (var p in puzzle)
            {
                _context.Puzzles.Remove(p);
            }

            foreach (var e in enemies)
            {
                _context.Enemies.Remove(e);
            }

            oldSave.RoomID = game.RoomID;
            oldSave.SaveName = game.SaveName;
            oldSave.ID = game.ID;
            oldSave.Username = oldSave.Username;
            oldSave.Health = game.Health;
            oldSave.Armour_ID = game.ShieldId;
            oldSave.Weapon_ID = game.WeaponId;

            await _context.SaveChangesAsync();


            foreach (var i in game.Inventory)
            {
                var item = new Inventory_Items();
                item.SaveID = oldSave.ID;
                item.ItemID = i;
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
            }

            foreach (var i in game.SlainEnemies)
            {
                var enemy = new Enemies_killed();
                enemy.SaveID = oldSave.ID;
                enemy.EnemyID = i;
                _context.Enemies.Add(enemy);
                await _context.SaveChangesAsync();
            }


            foreach (var i in game.PuzzleID)
            {
                var newpuzzle = new Puzzles();
                newpuzzle.Save_ID = oldSave.ID;
                newpuzzle.Puzzles_ID = i;
                _context.Puzzles.Add(newpuzzle);
                await _context.SaveChangesAsync();
            }

            foreach (var r in game.VisitedRooms)
            {
                var newroom = new VisitedRooms();
                newroom.SaveId = oldSave.ID;
                newroom.VistedRoomId = r;
                _context.VisitedRooms.Add(newroom);
                await _context.SaveChangesAsync();
            }

            return game;

        }


        public async Task<ActionResult<SaveDTO>> GetSaveByID(int SaveId)
        {
            Save save = await _context.Saves.FindAsync(SaveId);


            SaveDTO ToReturn = new SaveDTO();

            ToReturn.Username = save.Username;
            ToReturn.RoomID = save.RoomID;
            ToReturn.SaveName = save.SaveName;
            ToReturn.Health = save.Health;
            ToReturn.WeaponId = save.Weapon_ID;
            ToReturn.ShieldId = save.Armour_ID;
            ToReturn.ID = save.ID;

            var inv = _context.Items.Where(s => s.SaveID == save.ID).ToList();
            var enemies = _context.Enemies.Where(s => s.SaveID == save.ID).ToList();
            var puzzle = _context.Puzzles.Where(s => s.Save_ID == save.ID).ToList();
            var rooms = _context.VisitedRooms.Where(s => s.SaveId == save.ID).ToList();

            foreach (var room in rooms)
            {
                ToReturn.VisitedRooms.Add(room.VistedRoomId);
            }

            foreach (var i in inv)
            {
                ToReturn.Inventory.Add(i.ItemID);
            }

            foreach (var p in puzzle)
            {
                ToReturn.PuzzleID.Add(p.Puzzles_ID);
            }

            foreach (var e in enemies)
            {
                ToReturn.SlainEnemies.Add(e.EnemyID);
            }

            return ToReturn;
        }

        public async Task<ActionResult<List<Save>>> GetAllSaves()
        {
            

            var rooms = await _context.Saves.ToListAsync();

            return rooms;

        }


        public async Task<ActionResult<RoomDescription>> GetRoomDescription(int RDID)
        {

            var room = _context.RoomDescriptions.Where(i => i.RoomDescriptionID == RDID).FirstOrDefault();

            if (room == null)
            {
                return null;
            }

            return room;

        }
    }
}
