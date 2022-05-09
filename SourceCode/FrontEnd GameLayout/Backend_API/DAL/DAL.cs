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


        public async Task<ActionResult<SaveDTO>> SaveGame(SaveDTO saveDTO)
        {

            var newSave = new Save()
            {
                RoomID = saveDTO.RoomId,
                SaveName = saveDTO.SaveName,

            };

            _context.Saves.Add(newSave);

            await _context.SaveChangesAsync();

            var save = _context.Saves.Where(i => i.SaveName == saveDTO.SaveName).First();

            foreach (uint r in saveDTO.VisitedRooms)
            {
                var Visitedroom = new VisitedRooms()
                {
                    VistedRoomId = r,
                    SaveId = save.ID
                };

                _context.VisitedRooms.Add(Visitedroom);

                await _context.SaveChangesAsync();
            }

            return saveDTO;

        }


        public async Task<ActionResult<Save>> GetSaveByID(int SaveId)
        { 
            return await _context.Saves.FindAsync(SaveId);

        }

        public async Task<ActionResult<List<Save>>> GetAllSaves()
        {

            var rooms = await _context.Saves.ToListAsync();

            return rooms;

        }


        public RoomDescription GetRoomDescription(int RDID)
        {

            var room = _context.RoomDescriptions.Where(i => i.RoomDescriptionID == RDID).First();

            if (room == null)
            {
                return null;
            }

            return room;

        }
    }
}
