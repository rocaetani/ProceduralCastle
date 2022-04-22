
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Story
{
    public Room[] Rooms ;
    public Vector2Int Size;
    public Story(Room[] rooms)
    {
        Rooms = rooms;
    }

    public Story(Room[] rooms, Vector2Int size)
    {
        Rooms = rooms;
        Size = size;
    }
}
