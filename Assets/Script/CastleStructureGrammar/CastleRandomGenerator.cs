
using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public static class CastleRandomGenerator
{

    public static void SetSeed(int seed)
    {
        Random.InitState(seed);
    }
    
    public static Castle GenerateCastleDemo()
    {
        return new Castle(new Vector2Int(10,10), 
            new Story[]
            {
                new Story(new Room[]
                {
                    new Room(RoomType.ARMORY, RoomFunction.HIDE_KEY, new Vector2Int(10,8),new Vector2Int(0,0) ),
                    new Room(RoomType.BEDROOM, RoomFunction.REQUIRE_KEY, new Vector2Int(20,17), new Vector2Int(15,15)),
                    new Room(RoomType.DINING_ROOM, RoomFunction.SECRET_PASSAGE, new Vector2Int(50,40), new Vector2Int(80,80)) 
                }),
            });
    }

    public static Castle GenerateCastleFromJSON(string json)
    {
        return (Castle) JsonUtility.FromJson(json, typeof(Castle));
    }

    public static Story RandomizeStory(Vector2Int size)
    {
        int maxNumberOfRooms = VectorUtil.CalculateArea(size) / VectorUtil.CalculateArea(Constants.MinRoomSize) 
        int numberOfRooms = Random.Range(1, )
    }
    
    public static Story RandomizeStory(Vector2Int minSize, Vector2Int maxSize)
    {
        
    }
    
    
    
    
    
    public static Room RandomizeRoom(Vector2Int minSize, Vector2Int maxSize, RoomType? roomType = null, RoomFunction? roomFunction = null)
    {
        RoomType type = roomType ?? RandomizeRoomType();

        RoomFunction function = roomFunction ?? RandomizeRoomFunction();
        
        Vector2Int size = RandomizeSize(minSize, maxSize);

        return new Room(type, function, size);
    }


    private static RoomType RandomizeRoomType()
    {
        return (RoomType) Random.Range(0, Enum.GetValues(typeof(RoomType)).Length);
    }

    private static RoomFunction RandomizeRoomFunction()
    {
        return (RoomFunction) Random.Range(0, Enum.GetValues(typeof(RoomFunction)).Length);
    }

    private static Vector2Int RandomizeSize(Vector2Int minSize, Vector2Int maxSize)
    {
        int x = Random.Range(minSize.x, maxSize.y+1);
        int y = Random.Range(minSize.y, maxSize.y+1);
        
        return new Vector2Int(x,y);
    }


}
