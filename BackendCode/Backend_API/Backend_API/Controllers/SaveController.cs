#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend_API.Models;
using Backend_API.db;
using Backend_API.Models.DTO;
using Backend_API.DAL;

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveController : Controller
    {
        private readonly DaG_db _context;



        public SaveController(DaG_db context)
        {
            _context = context;
        }

        //private readonly Save_DAL _DAL = new Save_DAL();

        


        
        // GET: Players
        [HttpGet]

        public async Task<ActionResult<Save>> GetSave(int id)
        {
            var save = await _context.Saves.FindAsync(id);

            return save;

        }

        //public async Task<ActionResult<Save>> GetPlayer(int id)
        //{

            
        //    return await _DAL.GetSaveByID(id);
            
        //}


        [HttpPost]

        //public void PostPlayer(Save save)
        //{
        //    _DAL.SaveGame(save);
        //}

        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Save>> PostSave(PlayerDTO playerDTO)
        {


            var save = new Save()
            {
                RoomID = playerDTO.RoomId
            };

            _context.Add(save);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSave", new { id = save.ID });

        }




    }
}
