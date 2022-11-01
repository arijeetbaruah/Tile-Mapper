using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapper : MonoBehaviour
{
    public Tilemap tilemap;
    public List<TileDatabase> tileDatabases;

    string dataStr = "{\"datas\":[{\"position\":{\"x\":0,\"y\":1,\"z\":0,\"magnitude\":1.0,\"sqrMagnitude\":1},\"tileID\":\"block1\"},{\"position\":{\"x\":1,\"y\":1,\"z\":0,\"magnitude\":1.41421354,\"sqrMagnitude\":2},\"tileID\":\"block2\"},{\"position\":{\"x\":1,\"y\":0,\"z\":0,\"magnitude\":1.0,\"sqrMagnitude\":1},\"tileID\":\"block3\"}]}";

    private Dictionary<string, TileBase> tileRegistry = new Dictionary<string, TileBase>();

    public void Start()
    {
        tileRegistry.Clear();
        foreach(TileDatabase database in tileDatabases)
        {
            tileRegistry.Add(database.tileID, database.tile);
        }

        tilemap.ClearAllTiles();

        var data = JsonConvert.DeserializeObject<TileDatas>(dataStr);

        foreach(TileData tileData in data.datas)
        {
            tilemap.SetTile(tileData.position, tileRegistry[tileData.tileID]);
        }
    }

    public void GetData()
    {
        
    }
}

[System.Serializable]
public class TileDatabase
{
    public string tileID;
    public TileBase tile;
}

[System.Serializable]
public class TileData
{
    public Vector3Int position;
    public string tileID;
}

[System.Serializable]
public class TileDatas
{
    public List<TileData> datas;
}
