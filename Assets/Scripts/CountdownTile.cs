using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CountdownTile : MonoBehaviour {

    public Vector3Int Wall1TilePosition, Wall2TilePosition;
    public Tilemap WallTileMap;

	// Use this for initialization
	void Start () {
        GameObject wall1Tile = WallTileMap.GetInstantiatedObject(Wall1TilePosition);
        GameObject wall2Tile = WallTileMap.GetInstantiatedObject(Wall2TilePosition);

        wall2Tile.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
