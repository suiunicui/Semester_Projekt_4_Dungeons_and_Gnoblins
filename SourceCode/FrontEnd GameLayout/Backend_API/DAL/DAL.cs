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

        public async Task DeleteGame(int SaveId)
        {
            List<VisitedRooms> visitedList = _context.VisitedRooms.Where(i => i.SaveId == SaveId).ToList();

            Save Save = _context.Saves.Where(i => i.ID == SaveId).FirstOrDefault();

            _context.Saves.Remove(Save);

            await _context.SaveChangesAsync();

            foreach (VisitedRooms room in visitedList)
            {
                _context.VisitedRooms.Remove(room);
                await _context.SaveChangesAsync();
            }

        }


        public async Task<ActionResult<SaveDTO>> SaveGame(SaveDTO saveDTO)
        {
            //check if save already exits if it does delete it

            Save oldSave = _context.Saves.Where(i => i.ID == saveDTO.ID).FirstOrDefault();
            if(oldSave != null)
            {
                await DeleteGame(oldSave.ID);
            }

            var newSave = new Save()
            {
                RoomID = saveDTO.RoomId,
                SaveName = saveDTO.SaveName,

            };

            _context.Saves.Add(newSave);

            await _context.SaveChangesAsync();

            foreach (uint r in saveDTO.VisitedRooms)
            {
                var Visitedroom = new VisitedRooms()
                {
                    VistedRoomId = r,
                    SaveId = newSave.ID
                };

                _context.VisitedRooms.Add(Visitedroom);

                await _context.SaveChangesAsync();
            }

            return saveDTO;

        }


        public async Task<ActionResult<SaveDTO>> GetSaveByID(int SaveId)
        { 
            Save save = await _context.Saves.FindAsync(SaveId);

           

            List<VisitedRooms> visitedList = _context.VisitedRooms.Where(i => i.SaveId == SaveId).ToList();

            SaveDTO SaveDTO = new SaveDTO()
            {
                SaveName = save.SaveName,
                ID = save.ID,
                RoomId = save.RoomID,
                VisitedRooms = new List<uint>(),
            };

            foreach (VisitedRooms r in visitedList)
            {
                SaveDTO.VisitedRooms.Add(r.VistedRoomId);
            }

            return SaveDTO;


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
