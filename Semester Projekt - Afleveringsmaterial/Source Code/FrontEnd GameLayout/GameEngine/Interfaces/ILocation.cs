using GameEngine.Abstract_Class;
using GameEngine.Implementations;

namespace GameEngine.Interfaces;

public interface ILocation : IDescriptor
{
    public uint Id { get; set; }

    public Player Player { get; set; }
    public Enemy Enemy { get; set; }
    public List<Item>? Chest { get; set;}
    public void AddPlayer(Player player);
    public void RemovePlayer();
    public void AddEnemy(Enemy enemy);
    public void RemoveEnemy();
}
