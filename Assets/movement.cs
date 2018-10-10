using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public Rigidbody2D body;
    public int speed;
    public float drag;

	// Use this for initialization
	void Start () {
        drag = 3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        body.drag = drag;
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(Vector2.down * speed);
            body.MoveRotation(-90);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(Vector2.up * speed);
            body.MoveRotation(90);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector2.left * speed);
        }
    }
}
