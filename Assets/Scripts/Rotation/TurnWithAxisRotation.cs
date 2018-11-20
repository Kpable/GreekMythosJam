using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TurnWithAxisRotation : Rotation {

    // Variables that affect the rotation of the player
    [HeaderAttribute("Rotation Variables")]
    public float rotationSpeed = 180f;
    public string axisName = "Horizontal";

    private Rigidbody2D body;

    public override void Turn(PlayerControl movableObject)
    {
        // Player RigidBody2D
        body = movableObject.GetComponent<Rigidbody2D>();

        float hAxis = Input.GetAxisRaw(axisName);

        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float rotationChange = -hAxis * rotationSpeed * Time.deltaTime;
        
        // Apply this rotation to the rigidbody's rotation.
        body.rotation += rotationChange;
        //Debug.Log(name + ": -hAxis:" + -hAxis + " rotationChange: " + rotationChange);

    }
}
