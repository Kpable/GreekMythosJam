using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour {

    public GameObject LeftBound, RightBound, LowBound, HighBound;
    private Vector2 leftBound, rightBound, lowBound, highBound;
    public Rigidbody2D body;
    private float speed;
    private Vector2 direction;
    private int frames;

    // Use this for initialization
    void Start () {
        speed = .3f;
        frames = 20;
        //body.position = new Vector2(Random.Range(leftBound.x, rightBound.x), 
          //                          Random.Range(leftBound.y, rightBound.y));
        if (Random.value > .5f)
            direction = Vector2.up;
        else
            direction = Vector2.down;
 	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Random360();
        OscillateUpDown();
	}

    void OscillateUpDown()
    {
        body.velocity = speed * direction;

        frames--;
        if (frames <= 1)
        {
            if (direction == Vector2.up)
                direction = Vector2.down;
            else
                direction = Vector2.up;
            frames = 100;
        }
    }

    void Random360()
    {
        Vector2 direction = new Vector2();
        switch (Random.Range(0, 2))
        {
            case 0:
                direction = Vector2.up;
                break;
            case 1:
                direction = Vector2.down;
                break;
            case 2:
                direction = Vector2.left;
                break;
            case 3:
                direction = Vector2.right;
                break;
        }

        body.velocity = speed * direction;
        speed = Random.Range(1, 4);
    }
}
