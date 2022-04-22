using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower 
{
    public TowerLocation TowerLocation;
    public TowerRoof TowerRoof;
    public Vector2Int Size;
    public Vector2Int Position;
    public int ExtraFloors;
    public bool InsideOpen;

    public Tower(TowerLocation towerLocation, TowerRoof towerRoof, Vector2Int size, Vector2Int position, int extraFloors, bool insideOpen)
    {
        TowerLocation = towerLocation;
        TowerRoof = towerRoof;
        Size = size;
        Position = position;
        ExtraFloors = extraFloors;
        InsideOpen = insideOpen;
    }
}
