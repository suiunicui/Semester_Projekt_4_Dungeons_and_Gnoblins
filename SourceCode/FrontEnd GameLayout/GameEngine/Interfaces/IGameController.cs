namespace GameEngine.Interfaces;

public interface IGameController
{
    ILocation CurrentLocation { get; set; }
    ILog Move(Direction dir);

    void LoadGame(int id);
}

