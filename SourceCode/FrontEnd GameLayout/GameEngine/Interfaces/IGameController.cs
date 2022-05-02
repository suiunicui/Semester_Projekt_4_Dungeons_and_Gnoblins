namespace GameEngine.Interfaces;

public interface IGameController
{
    ILog Move(Direction dir);
    void LoadGame(int id);
}

