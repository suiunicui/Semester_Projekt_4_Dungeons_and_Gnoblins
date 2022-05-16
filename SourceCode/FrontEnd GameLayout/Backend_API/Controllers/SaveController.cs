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
using Microsoft.AspNetCore.Authorization;

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaveController : Controller
    {
        private readonly DAL.DAL _save;


        public SaveController(DaG_db context)
        {
            _save = new DAL.DAL(context);

        }

        // GET: Save
        [HttpGet]

        public async Task<ActionResult<SaveDTO>> GetSave(int id)
        {
            var identity = User.Identity;
          
            
            var save = await _save.GetSaveByID(id);

            if (save == null)
            {
                return NotFound();
            }

            if (identity.Name == save.Value.Username.ToLower())
            {
                return save;
            }
            else
                return Unauthorized();

        }

        // GET: list of Saves
        [HttpGet("Get List Of Saves")]

        public async Task<ActionResult<List<Save>>> GetListOfSave()
        {
            var identity = User.Identity;

            var saveList = await _save.GetAllSaves();

            var currentUserSaves = saveList.Value.Where(u => u.Username.ToLower() == identity.Name).ToList();

            if (currentUserSaves != null)
            {
                return currentUserSaves;
            }
            else
                return Unauthorized();

        }

        [HttpGet("Get_Room_Description"), AllowAnonymous]
        

        public async Task<ActionResult<RoomDescription>> GetRoomDescription(int id)
        {


            return await _save.GetRoomDescription(id);

        }


        // Post: Save
        [HttpPost]

        public async Task<ActionResult<SaveDTO>> PostSave(SaveDTO saveDTO)
        {

            return await _save.SaveGame(saveDTO);

        }




    }
}
