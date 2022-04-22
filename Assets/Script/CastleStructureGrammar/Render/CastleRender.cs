using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleRender : MonoBehaviour
{
    public GameObject WallPrefab;
    public GameObject FloorPrefab;

    public void RenderCastle(Castle castle)
    {
        
        GameObject castleContainer = new GameObject("Castle");

     
        switch (castle.CastleShape)
        {
            case CastleShape.Rectangle: 
                RenderSpace(Vector2Int.zero, castle.Size, 0);
                break;
            case CastleShape.Uneven:
                break;
            default:
                break;
        }

        int storyNumber = 1;
        foreach (Story story in castle.Stories)
        {
            RenderStory(story, storyNumber).transform.SetParent(castleContainer.transform);
            storyNumber++;
        }

        int towerNumber = 1;
        
        foreach (Tower tower in castle.Towers)
        {
            RenderTower(tower, castle.Stories.Length, towerNumber).transform.SetParent(castleContainer.transform);
            towerNumber++;
        }
    }
    

    private GameObject RenderStory(Story story, int storyNumber)
    {
        GameObject storyContainer = new GameObject("Story " + storyNumber);

        foreach (Room room in story.Rooms)
        {
            GameObject roomContainer = RenderRoom(room, storyNumber);
            roomContainer.transform.SetParent(storyContainer.transform);
        }

        return storyContainer;
    }

    private GameObject RenderRoom(Room room, int floorNumber)
    {

        GameObject roomContainer = new GameObject("Room: " + room.RoomType);

        GameObject spaceContainer = RenderSpace(room.Point, room.Size, floorNumber);
        spaceContainer.transform.SetParent(roomContainer.transform);

        return roomContainer;
    }

    private GameObject RenderTower(Tower tower, int castleHeight, int towerNumber)
    {
        GameObject towerContainer = new GameObject("Tower " + towerNumber);
        
        int levels = tower.ExtraFloors + castleHeight;

        for (int i = 1; i <= levels; i++)
        {
            GameObject towerLevelContainer = new GameObject("Tower Level " + i);
            towerLevelContainer.transform.SetParent(towerContainer.transform);

            RenderSpace(tower.Position, tower.Size, i - 1).transform.SetParent(towerLevelContainer.transform);
        }

        return towerContainer;

    }

    private GameObject RenderSpace(Vector2Int startPoint, Vector2Int size, int height)
    {
        GameObject spaceContainer = new GameObject("Space");
        
        
        GameObject wallContainer = RenderWalls(startPoint, size, height);
        wallContainer.transform.SetParent(spaceContainer.transform);
        
        GameObject floorContainer = RenderFloors(startPoint, size, height);
        floorContainer.transform.SetParent(spaceContainer.transform);
        

        return spaceContainer;
    }

    private GameObject RenderWalls(Vector2Int startPoint, Vector2Int size, int height)
    {
        GameObject wallContainer = new GameObject("Walls");
        for (int i = startPoint.x; i < startPoint.x  + size.x; i++)
        {
            Vector2 wallPosition = new Vector2(i+ 0.5f, startPoint.y);
            InstantiateWall(wallPosition, Orientation.Bottom, height).transform.SetParent(wallContainer.transform);
            wallPosition.y += size.y;
            InstantiateWall(wallPosition, Orientation.Top, height).transform.SetParent(wallContainer.transform);
        }
        
        for (int i = startPoint.y; i < startPoint.y  + size.y; i++)
        {
            Vector2 wallPosition = new Vector2(startPoint.x, i + 0.5f);
            InstantiateWall(wallPosition, Orientation.Left, height).transform.SetParent(wallContainer.transform);
            wallPosition.x += size.x;
            InstantiateWall(wallPosition, Orientation.Right, height).transform.SetParent(wallContainer.transform);
        }
        
        return wallContainer;
    }

    private GameObject RenderFloors(Vector2Int startPoint, Vector2Int size, int height)
    {
        GameObject floorContainer = new GameObject("Floor");
        for (int i = startPoint.x; i < startPoint.x  + size.x; i++)
        {
            for (int j = startPoint.y; j < startPoint.y  + size.y; j++)
            {
                Vector2 floorPosition = new Vector2(i + 0.5f, j + 0.5f );
                GameObject floor = InstantiateFloor(floorPosition,  height);
                floor.transform.SetParent(floorContainer.transform);

            }
        }

        return floorContainer;
    }

    private GameObject InstantiateWall(Vector2 position, Orientation orientation, int floorNumber)
    {
        Vector3 objectPosition = new Vector3(position.x, Constants.WALL_HIGHT * floorNumber , position.y);
        GameObject wall = Instantiate(WallPrefab, objectPosition, Quaternion.identity);
        
        if (orientation == Orientation.Left || orientation == Orientation.Right)
        {
            wall.transform.Rotate(Vector3.up, 90);
        }

        return wall;
    }
    
    private GameObject InstantiateFloor(Vector2 position, int floorNumber)
    {
        Vector3 objectPosition = new Vector3(position.x, Constants.GROUND_HIGHT + (floorNumber * Constants.WALL_HIGHT), position.y);
        return Instantiate(FloorPrefab, objectPosition, Quaternion.identity);
    }


}
