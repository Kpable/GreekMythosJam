using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    public Rigidbody2D body;
    private float speed;
    private Vector2 direction;
    private int frames;
    public int FRAME_MAX = 30;
    private bool toggleWait;

    // Use this for initialization
    void Start () {
        frames = FRAME_MAX;
        speed = .05f;
        toggleWait = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Random360();
	}

    void Random360()
    {
        if (frames <= 1 && toggleWait == false)
        {
            switch (UnityEngine.Random.Range(0, 4))
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

            speed = .05f;//speed = Random.Range(1, 4);
            frames = FRAME_MAX;
            toggleWait = true;
        }
        body.velocity = speed * direction;
        if(toggleWait)
        {
            frames++;
            if(frames >= FRAME_MAX)
            {
                toggleWait = false;
            }
        }
        else
        {
            frames--;
            toggleWait = false;
        }
    }

    public void Disappear()
    {
        DestroyImmediate(this, true);
    }
}
