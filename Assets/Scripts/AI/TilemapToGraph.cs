using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using System.Linq;

public class TilemapToGraph : MonoBehaviour {

    public Tilemap groundTileMap;               // we want this to know what within our scan is traversable
    public List<Tilemap> collisionTilemaps;
    public BoundsInt graphBounds;

    public Vector3Int tilemapGridScale;

    Graph mGraph;

    public Graph Graph { get
        {
            if (mGraph == null)
                mGraph = CreateGraphFromTileMaps(groundTileMap, collisionTilemaps, graphBounds);

            return mGraph;
        } }

    private void Awake()
    {
        Assert.IsNotNull(groundTileMap, "GroundTilemap is null");
        //Debug.Log("Floor:" + Mathf.FloorToInt(bounds.size.x/2f));
        Debug.Log("Child Count: " + transform.childCount);
    }

    // Use this for initialization
    void Start () {
        //graph = CreateGraphFromTileMaps(groundTileMap, collisionTilemaps, graphBounds);
        //graph.Dump();
        //graph.WorldPointToNode(new Vector3(-42, 30, 0)).Dump();
    }

    private void Update()
    {
            
    }

    public Graph CreateGraphFromTileMaps(Tilemap ground, List<Tilemap> collisionTileMaps, BoundsInt bounds)
    {
        Graph graph = new Graph(bounds.size.x, bounds.size.y);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                int xOffset = x - bounds.size.x / 2;
                int yOffset = y - bounds.size.y / 2;

                if (ground.HasTile(xOffset, yOffset))
                {
                    bool traversable = true;
                    foreach (var collisionMap in collisionTileMaps)
                    {
                        traversable = !collisionMap.HasTile(xOffset, yOffset);
                        if (!traversable) break;
                    }

                    Node node = new Node(ground.CellToWorld(xOffset, yOffset),
                            new Vector3Int(x, y, 0),
                            traversable);

                    graph.AddNode(node);
                }
            }
        }

        return graph;
    }


    private void OnDrawGizmosSelected()
    {
        //bounds.DrawGizmo();
        graphBounds.DrawGizmo(tilemapGridScale);
        if (mGraph != null)
        {
            mGraph.DrawGizmo(tilemapGridScale);
        }
    }
}