using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathfindingAlgorithm : ScriptableObject {

    public abstract NodePath FindPath(Vector3 start, Vector3 finish, Graph graph);
}
