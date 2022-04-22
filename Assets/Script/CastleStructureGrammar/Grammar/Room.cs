using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Room 
{    
    public RoomType RoomType;
    
    public RoomFunction RoomFunction;

    public Vector2Int Size;

    //Point in the world where the room is instanciated(left bottom of the room)
    public Vector2Int Point;

    public Room(RoomType roomType, RoomFunction roomFunction, Vector2Int size)
    {
        RoomType = roomType;
        RoomFunction = roomFunction;
        Size = size;
        Point = Vector2Int.zero;
    }
    
    public Room(RoomType roomType, RoomFunction roomFunction, Vector2Int size, Vector2Int point)
    {
        RoomType = roomType;
        RoomFunction = roomFunction;
        Size = size;
        Point = point;

    }
    
}
