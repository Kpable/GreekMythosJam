using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kpable/AI/Pathfinding/AstarPathfindingAlgorithm")]
public class AstarPathfinding : PathfindingAlgorithm
{
    public bool mooreNeighborhood = true;   // 8 directions

    List<Node> openSet;
    List<Node> closedSet;

    Transform start, target;

    public override NodePath FindPath(Vector3 start, Vector3 finish, Graph graph)
    {
        //Debug.Log(name +  ": Finding path");
        Node startNode = graph.WorldPointToNode(start, true);
        Node targetNode = graph.WorldPointToNode(finish, true);
        string output = "";
        startNode.Dump(ref output, "Astar - Finding path from ");
        targetNode.Dump(ref output, " to ");
        Debug.Log(output);
        //Debug.Log(name + ": Finding path from (" + startNode.X + "," + startNode.Y + ") to (" + targetNode.X + "," + targetNode.Y + ")");

        // prevents changing the path if we happen to be starting closest to node thats not traversable
        if (!startNode.Traversable)
            return null;

        openSet = new List<Node>();
        closedSet = new List<Node>();

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node node = openSet[0];
            for (int i = 0; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
                {
                    if (openSet[i].hCost < node.hCost)
                        node = openSet[i];
                }
            }

            openSet.Remove(node);
            closedSet.Add(node);

            if (node == targetNode)
            {
                return RetracePath(startNode, targetNode); 
            }

            foreach (var neighbor in graph.GetNeighbors(node, mooreNeighborhood))
            {
                if (neighbor == null) Debug.Log("no neighbor");

                // If neighbor is not traversable or we've already processed it, move on
                if (!neighbor.Traversable || closedSet.Contains(neighbor))
                    continue;

                int newNeighborCost = node.gCost + GetDistance(node, neighbor);
                if (newNeighborCost < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newNeighborCost;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = node;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null;
    }

    private int GetDistance(Node node, Node neighbor)
    {
        // using multiply by 10 and 14 approach for calculations
        // uses the Euclidean distance for diagonals which is ~1.4
        int xDistance = Mathf.Abs(node.GraphPosition.x - neighbor.GraphPosition.x);
        int yDistance = Mathf.Abs(node.GraphPosition.y - neighbor.GraphPosition.y);
        //Debug.Log(name + ": Distance: " + "(" + xDistance  + ", " + yDistance + ")");
        // This produces (1,0) (1, 1) or (0,1) pairs.


        if (xDistance > yDistance)
        {
            // (1, 0) 14 * 1 + 10 * (1 - 0) = 28           
            return 14 * yDistance + 10 * (xDistance - yDistance);
        }

        // (0, 1) 14 * 0 + 10 * (1 - 0) = 10
        // (1, 1) 14 * 1 + 10 * (1 - 1) = 14

        return 14 * xDistance + 10 * (yDistance - xDistance);
    }

    private NodePath RetracePath(Node startNode, Node targetNode)
    {
        //Debug.Log(name + ": Retracing path");

        NodePath path = new NodePath();
        Node currentNode = targetNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(startNode);

        path.Reverse();

        return path;
    }
}
