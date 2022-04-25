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
        private readonly DAL.DAL _save;


        public SaveController(DaG_db context)
        {
            _save = new DAL.DAL(context);

        }

        // GET: Save
        [HttpGet]

        public async Task<ActionResult<Save>> GetSave(int id)
        {
            var save = _save.GetSaveByID(id);
            if(save == null)
            {
                return NotFound();
            }
            return await save;

        }

        // GET: list of Saves
        [HttpGet]

        public async Task<ActionResult<List<Save>>> GetSave()
        {
            return await _save.GetAllSaves();

        }


        // Post: Save
        [HttpPost]

        public async Task<ActionResult<Save>> PostSave(SaveDTO saveDTO)
        {

            return await _save.SaveGame(saveDTO);

        }




    }
}
