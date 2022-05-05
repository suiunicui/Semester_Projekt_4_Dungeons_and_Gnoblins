﻿using GameEngine.Implementations;

namespace GameEngine.Interfaces;

public interface IGameController
{
    IMap GameMap { get; set; }
    ILocation CurrentLocation { get; set; }
    Player CurrentPlayer { get; set; }
    List<uint> VisitedRooms { get; set; }
    ILog Move(Direction dir);
    void Savegame();
    Task LoadGame(int id);


}

