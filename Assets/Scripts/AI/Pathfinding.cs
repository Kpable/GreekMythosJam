using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pathfinding : MonoBehaviour {

    public PathfindingAlgorithm pathFindingAlgorithm;

    public NodePath Path { get; set; }

    // Use this for initialization
    void Start () 
    {
    }
	
	// Update is called once per frame
	void Update () {
       
            
	}

    public void FindPath(Vector3 targetPos, Graph graph)
    {
        Path = pathFindingAlgorithm.FindPath(transform.position, targetPos, graph);
        if (Path == null)
            Debug.Log("Unable to retrieve path to " + targetPos);
        //else
        //    path.Dump("Pathfinding");
    }

    public void OnDrawGizmosSelected()
    {
        if(Path != null)
        {
            Path.DrawGizmo(Vector3.one * 10);
        }
    }
}
