using GameEngine.Abstract_Class;
using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class BaseMap : IMap
{
    public ILocation[] Rooms { get; set; }
    public LinkedList<int>[] MapLayout { get; set; }

    public BaseMap(IMapCreator mapCreator)
    {
        MapLayout = GenerateMapLayoutFromFile(mapCreator.FilePath);
        Rooms = GenerateRooms(mapCreator.FilePath, mapCreator.EnemyFilePath, mapCreator.ItemFilePath);

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

    private ILocation[] GenerateRooms(string LayoutFilePath, string enemyFilePath, string itemFilePath)
    {
        int mapSize = CalculateMapSize(LayoutFilePath);
        ILocation[] rooms = new ILocation[mapSize];

        for (int i = 0; i < mapSize; i++)
        {
            rooms[i] = new Room((uint) i);
        }

        StreamReader reader = new StreamReader(enemyFilePath);
        while(!reader.EndOfStream)
        {
            string s = reader.ReadLine();
            uint[] ss = s.Split(",").Select(uint.Parse).ToArray();

            for (int i = 0; i < mapSize; i++)
            {
                if (i == ss[0])
                {
                    rooms[i].AddEnemy(new Enemy(ss[1], ss[2], (ss[3], ss[4]), ss[5]));
                    break;
                }
            }
        }
        reader.Close();

        reader = new StreamReader(itemFilePath);
        while(!reader.EndOfStream)
        {
            string s = reader.ReadLine();
            uint[] ss = s.Split(",").Select(uint.Parse).ToArray();

            for(int i = 0; i < mapSize; i++)
            {
                if (i == ss[0])
                {
                    switch (ss[1])
                    {
                        case 1:
                            rooms[i].Chest.Add(new Sword((ss[2], ss[3]), ss[4], ss[5]));
                            break;
                        case 2:
                            rooms[i].Chest.Add(new Shield(ss[2]));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        reader.Close();
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