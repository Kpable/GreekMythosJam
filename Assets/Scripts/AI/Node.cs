using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
    public Node parent;
    public int gCost;
    public int hCost;
    public int fCost { get { return gCost + hCost; } }

    public int X { get { return Mathf.RoundToInt(WorldPosition.x); } }
    public int Y { get { return Mathf.RoundToInt(WorldPosition.y); } }
    public Vector3Int GraphPosition { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public bool Traversable { get; private set; }

    public Node(Vector3 worldPosition, Vector3Int graphPosition, bool traversable)
    {
        WorldPosition = worldPosition;
        GraphPosition = graphPosition;
        this.Traversable = traversable;
    }

    internal void Dump(string label = "")
    {
        label += string.IsNullOrEmpty(label) ? "" : " - ";
        Debug.Log(label + "Node: " +
            "Graph Position: " + GraphPosition + ", " +
            "World Position: " + WorldPosition + ", " + 
            "Traversable: " + Traversable
            );
    }

    internal void Dump(ref string output, string label = "")
    {
        label += string.IsNullOrEmpty(label) ? "" : " - ";
        output += label + "Node: " +
            "Graph Position: " + GraphPosition + ", " +
            "World Position: " + WorldPosition + ", " +
            "Traversable: " + Traversable
            ;
    }
}
