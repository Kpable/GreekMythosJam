using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TopDownMovement : Movement {

    [HeaderAttribute("Movement Variables")]
    public float speed = 5f;
    public Rotation rotation;

    private Rigidbody2D body; 

    public override void Move(PlayerControl movableObject)
    {
        body = movableObject.GetComponent<Rigidbody2D>();
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.up* vAxis * speed * Time.deltaTime;
        movement += Vector2.right * hAxis * speed * Time.deltaTime;
        //Debug.Log(name + ": vAxis: " + vAxis);

        //Debug.Log(name + ": movement: " + movement);
        body.MovePosition(body.position + movement);

        if(rotation)
            rotation.Turn(movableObject);
    }
}
