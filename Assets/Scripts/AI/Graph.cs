using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Graph
{
    Node[,] nodes;
    int width, height;

    public Graph(int width, int height)
    {
        this.width = width;
        this.height = height;
        nodes = new Node[width, height];
    }

    public void AddNode(Node node)
    {
        nodes[node.GraphPosition.x, node.GraphPosition.y] = node;
    }

    public Node WorldPointToNode(Vector3 worldPosition, bool onlyTraversableNodes = false)
    {
        Node closestNode = nodes[0, 0];
        float shortestDistance = float.MaxValue;

        // Adjust Z
        worldPosition.z = closestNode.WorldPosition.z;

        foreach (var node in nodes)
        {
            if (onlyTraversableNodes && !node.Traversable)
                continue;

            float sqrMagnitude = (worldPosition - node.WorldPosition).sqrMagnitude;
            if (sqrMagnitude < shortestDistance)
            {
                closestNode = node;
                shortestDistance = sqrMagnitude;
            }

        }

        return closestNode;
    }

    public Node GetNode(int x, int y)
    {
        //Debug.Log("Graph - GetNode: (" + x + "," + y + "), width: " + width + " height: " + height);
        if (x < width && y < height && x >= 0 && y >= 0)
            return nodes[x, y];
        return null;
    }

    public List<Node> GetNeighbors(Node node, bool mooreNeighborhood = true)
    {
        List<Node> neighbors = new List<Node>();

        // get neighbors in all eight directions
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                // Skip this node
                if (x == 0 && y == 0)
                    continue;

                if (!mooreNeighborhood)
                {
                    if (Mathf.Abs(x + y) != 1) continue;
                }

                int xCheck = node.GraphPosition.x + x;
                int yCheck = node.GraphPosition.y + y;

                // If the position we're checking is greater than 0 but within the bounds of the graph size
                if (xCheck >= 0 && xCheck < width &&
                    yCheck >= 0 && yCheck < height)
                {
                    // Debug to check why there was null neighbors.
                    // For nodes that do not have ground tiles as neighbors are null
                    // Occurs when the scan area is greater than there is ground on the floor. 
                    //if (graph[xCheck, yCheck] == null)
                    //{
                    //    Debug.Log("No Neighbor");
                    //    Debug.Log(name + ": found neighbor for Node at " + "(" + node.WorldPosition + "): " + "(" + xCheck + ", " + yCheck + ")");
                    //}

                    if (nodes[xCheck, yCheck] != null)
                        neighbors.Add(nodes[xCheck, yCheck]);
                    //Debug.Log(name + ": found neighbor for Node at " + "(" + node.WorldPosition + "): " + graph[xCheck, yCheck].WorldPosition);
                    ;
                }
            }
        }
        return neighbors;
    }

    public void Dump()
    {
        foreach (var node in nodes)
        {
            node.Dump("Graph");
        }
    }

    public void DrawGizmo(Vector3 scale)
    {
        scale *= 0.9f;
        if (nodes != null)
        {
            foreach(var node in nodes)
            {
                Gizmos.color = (node.Traversable) ? Color.white : Color.red;
                Gizmos.DrawWireCube(node.WorldPosition, scale);

            }
        }
    }

    internal Node GetNearestTraversableNode(Vector3 worldPosition, bool onlyTraversableNodes = false)
    {
        Node closestNode = nodes[0, 0];
        float shortestDistance = float.MaxValue;

        // Adjust Z
        worldPosition.z = closestNode.WorldPosition.z;

        foreach (var node in nodes)
        {
            float sqrMagnitude = (worldPosition - node.WorldPosition).sqrMagnitude;
            if (sqrMagnitude < shortestDistance)
            {
                closestNode = node;
                shortestDistance = sqrMagnitude;
            }
        }

        return closestNode;
    }
}
