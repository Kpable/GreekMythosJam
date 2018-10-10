using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CountdownTile : TileBase {

    public Vector3Int AlternatePosition;
    public Sprite sprite;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        Debug.Log("GetTileData");
        tileData.sprite = sprite;
        tileData.colliderType = Tile.ColliderType.Sprite;
        base.GetTileData(position, tilemap, ref tileData);
    }

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        Debug.Log("StartUp");
        Debug.Log("GameObject is " + go == null);
        if (go)
        {
            go.AddComponent<OnTriggerEnter2DEvent>().OnEvent += OnTriggerEnter2D;
        }

        return true;
    }

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        Debug.Log("RefreshTile");
        base.RefreshTile(position, tilemap);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.name);
    }
}
