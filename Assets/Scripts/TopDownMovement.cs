using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TopDownMovement : Movement {

    public float speed = 15f; 

    public override void Move(PlayerControl movableObject)
    {
        Rigidbody2D body = movableObject.GetComponent<Rigidbody2D>();
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Debug.Log(name + ": speed: " + speed);

        Vector2 movement = movableObject.transform.up * vAxis * speed * Time.deltaTime;
        movement += Vector2.right * hAxis * speed * Time.deltaTime;
        //Debug.Log(name + ": vAxis: " + vAxis);

        //Debug.Log(name + ": movement: " + movement);
        body.MovePosition(body.position + movement);

        Turn();
    }

    public void Turn()
    {

    }

}
