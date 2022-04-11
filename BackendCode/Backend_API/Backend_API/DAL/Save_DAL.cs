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

        //private readonly MyDbContext _context;
        private readonly DaG_db _context;



        public async void SaveGame(PlayerDTO playerDTO)
        {
            var newSave = new Save()
            {
                RoomID = playerDTO.RoomId
            };

            _context.Add(newSave);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetPlayer", new { id = player.PlayerId });


            //_context.Saves.Add(save);

            //_context.SaveChanges();

        }


        public async Task<ActionResult<Save>> GetSaveByID(int SaveId)
        {

            

            var save = await _context.Saves.FindAsync(SaveId);



            return save;

            //foreach (var save in saves)
            //{
            //    if (save.ID == SaveId)
            //        return save;
            //}

            //return null;

        }
    }
}
