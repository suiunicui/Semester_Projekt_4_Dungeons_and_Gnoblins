using Backend_API.db;
using Backend_API.Models;
using Backend_API.Models.DTO;

namespace Backend_API.DAL
{
    public class Player_DAL
    {

        private readonly DaG_db _context;

        public Player_DAL(DaG_db context)
        {
            _context = context;
        }

        //async public Task<PlayerDTO> CreatePlayer(PlayerDTO playerDTO)
        //{
        //    var player = new Player()
        //    {
        //        RoomId = playerDTO.RoomId
        //    };

        //    _context.Add(player);
        //    await _context.SaveChangesAsync();
        //    return PlayerToPlayerDTO(player);
        //}

        //public PlayerDTO PlayerToPlayerDTO(Player player)
        //{
        //    var playerDTO = new PlayerDTO()
        //    {
        //        RoomId = player.RoomId
        //    };
        //    return playerDTO;
        //}

    }
}
