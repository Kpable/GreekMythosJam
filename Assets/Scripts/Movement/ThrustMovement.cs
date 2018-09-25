using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ThrustMovement : Movement {

    [HeaderAttribute("Movement Variables")]
    public float thrust = 25f;
    public Rotation rotation;

    private Rigidbody2D body;

    public override void Move(PlayerControl movableObject)
    {
        body = movableObject.GetComponent<Rigidbody2D>();
        float vAxis = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(0, vAxis * thrust * Time.deltaTime, 0);

        body.AddForce(body.transform.rotation * force);

        rotation.Turn(movableObject);
    }

}
