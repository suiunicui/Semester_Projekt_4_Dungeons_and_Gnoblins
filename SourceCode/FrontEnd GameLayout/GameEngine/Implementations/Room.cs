#nullable disable
using Backend_API.Models;
using GameEngine.Abstract_Class;
using GameEngine.Exceptions;
using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class Room : ILocation
{
    public Room(uint roomId)
    {
        Id = roomId;
    }


    public string Description { get; set; }
    public uint Id { get; set; }
    public Player Player { get; set; }
    public Enemy Enemy { get; set; }
    public List<Item> Chest { get; set; } = new List<Item>();

    public void AddPlayer(Player player)
    {
        if (Player != null)
        {
            throw new MemberOverwriteException(
                "Player is already present in the room, please remove the current instance first."
            );
        }
        Player = player;
    }

    public void RemovePlayer()
    {
        Player = null;
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemy = enemy;
    }

    public void RemoveEnemy()
    {
        Enemy = null;
    }


}