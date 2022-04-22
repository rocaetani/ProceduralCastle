
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CastleDemo : MonoBehaviour
{
    public CastleRender CastleRender;
    // Start is called before the first frame update
    void Start()
    {
        /*
        Room room = new Room(RoomType.ARMORY, RoomFunction.NORMAL, new Vector2Int(100,50));
        room.Point = new Vector2Int(0,0);
        CastleRender.RenderCastle(CastleGenerator.GenerateCastleDemo());
        
        string json2 = JsonUtility.ToJson(room);
        Castle castle = CastleGenerator.GenerateCastleDemo();
        string json = JsonUtility.ToJson(castle);
        Debug.Log(json);
        */
        int seed = 2;// Random.Range(0, 100000000);
        Debug.Log(seed);
        //CastleRandomGenerator.SetSeed(seed);
        for (int i = 0; i < 30; i++)
        {
            Debug.Log((RoomType) Random.Range(0, Enum.GetValues(typeof(RoomType)).Length));
        }
        

    }
    
}
