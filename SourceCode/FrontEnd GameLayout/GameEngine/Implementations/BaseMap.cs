using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class BaseMap : IMap
{
    public ILocation[] Rooms { get; set; }
    public LinkedList<int>[] MapLayout { get; set; }

    public BaseMap(IMapCreator mapCreator)
    {
        MapLayout = GenerateMapLayoutFromFile(mapCreator.FilePath);
        Rooms = GenerateRooms(mapCreator.FilePath);
    }

    private LinkedList<int>[] GenerateMapLayoutFromFile(string filePath)
    {
        LinkedList<int>[] mapLayout = CreateConnectionsBetweenRoomsFromLayoutFile(filePath);
        return mapLayout;
    }

    private LinkedList<int>[] CreateConnectionsBetweenRoomsFromLayoutFile(string filepath)
    {
        int mapSize = CalculateMapSize(filepath);
        LinkedList<int>[] connections = new LinkedList<int>[mapSize];

        StreamReader sr = new StreamReader(filepath);
        int index = 0;
        while (!sr.EndOfStream)
        {
            string? linkingString = sr.ReadLine();
            connections[index++] = CreateRoomLink(linkingString);
        }

        sr.Close();

        return connections;
    }

    private LinkedList<int> CreateRoomLink(string linkingString)
    {
        int[] link = linkingString.Split(",").Select(int.Parse).ToArray();
        return new LinkedList<int>(link);
    }

    private int CalculateMapSize(string LayoutFilePath)
    {
        StreamReader sr = new StreamReader(LayoutFilePath);
        int mapSize = 0;
        while (!sr.EndOfStream)
        {
            sr.ReadLine();
            mapSize++;
        }

        sr.Close();
        return mapSize;
    }

    private ILocation[] GenerateRooms(string LayoutFilePath)
    {
        int mapSize = CalculateMapSize(LayoutFilePath);
        ILocation[] rooms = new ILocation[mapSize];

        for (int i = 0; i < mapSize; i++)
        {
            rooms[i] = new Room((uint) i);
        }
        return rooms;
    }
    public ILocation GetLocationByDirection(ILocation currentRoom, Direction direction)
    {
        int newLocationId = MapLayout[currentRoom.Id].ElementAt((int) direction);
        if (!ValidDirection(newLocationId))
        {
            return currentRoom;
        }
        
        ILocation newLocation = Rooms[newLocationId];
        return newLocation;
    }

    private bool ValidDirection(int locationId)
    {
        return locationId > 0;
    }

    
}