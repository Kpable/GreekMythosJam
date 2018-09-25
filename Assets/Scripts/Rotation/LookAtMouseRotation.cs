using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LookAtMouseRotation : Rotation {

    // Variables that affect the rotation of the player
    [HeaderAttribute("Rotation Variables")]
    public float cameraRadius = 0.001f;
    public float directionOffset = 0f;

    private Rigidbody2D body;

    public override void Turn(PlayerControl movableObject)
    {
        // Player RigidBody2D
        body = movableObject.GetComponent<Rigidbody2D>();

        //Player rotation
        Vector2 playerOnScreen = Camera.main.WorldToViewportPoint(body.position);

        // Position of Mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Vector2.Distance(playerOnScreen, mouseOnScreen) >= 0.001f)
        {
            // Angle between player and mouse
            float angle = Mathf.Atan2(playerOnScreen.y - mouseOnScreen.y, playerOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

            // Rotate
            body.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + directionOffset));
        }
        
    }

}
