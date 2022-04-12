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
    public class Save_DAL
    {
        private readonly DaG_db _context;

        public Save_DAL(DaG_db context)
        {
            _context = context;

        }


        public async Task<ActionResult<Save>> SaveGame(SaveDTO saveDTO)
        {

            var newSave = new Save()
            {
                RoomID = saveDTO.RoomId
            };

            _context.Saves.Add(newSave);
            await _context.SaveChangesAsync();

            return newSave;

        }


        public async Task<ActionResult<Save>> GetSaveByID(int SaveId)
        { 
            return await _context.Saves.FindAsync(SaveId);

        }
    }
}
