using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CastleGenerator
{

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

    public static Castle GenerateCastleFromJSON(String json)
    {
        return (Castle) JsonUtility.FromJson(json, typeof(Castle));
    }


    public static Story GenerateFloor(Room[] rooms)
    {
        return new Story(rooms);
    }
    

    public static Room GenerateRoom(int roomType, int roomFunction, Vector2Int size)
    {
        return new Room((RoomType) roomType , (RoomFunction) roomFunction, size);
    }
    
}
