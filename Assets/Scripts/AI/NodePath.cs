using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePath : List<Node> {
    

    public void Dump(string label = "")
    {
        label += string.IsNullOrEmpty(label) ? "" : " - ";

        foreach (var node in this)
        {
            node.Dump(label + "NodePath");
        }
    }

    public void DrawGizmo(Vector3 scale)
    {
        scale *= 0.8f;
       
        foreach (var node in this)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(node.WorldPosition, scale);
        }
       
    }
}
