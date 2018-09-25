using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rotation : ScriptableObject
{
    public abstract void Turn(PlayerControl movableObject);
}
