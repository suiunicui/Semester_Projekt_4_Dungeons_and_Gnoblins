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
            

            var saves = await _context.Saves.ToListAsync();

            return saves;

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
