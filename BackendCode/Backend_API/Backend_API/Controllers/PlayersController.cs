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

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {
        private readonly DaG_db _context;

        public PlayersController(DaG_db context)
        {
            _context = context;
        }

        
        // GET: Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
            return await _context.Players.ToListAsync();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Player>> PostPlayer(PlayerDTO playerDTO)
        {

            var player = new Player()
            {
                RoomId = playerDTO.RoomId
            };

            _context.Add(player);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPlayer", new { id = player.PlayerId });

        }


    }
}
