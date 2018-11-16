using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Player : MonoBehaviour {

    // Game Objects
    public Rigidbody2D playerBody;
    public GameObject sacrificePrefab;
    public GameObject cloudPrefab;
    public GameObject spawnerPrefab;

    // Player Stats
    public int sacrificeCount = 0;
    public int torchCount = 0;

    // Constants
    public int MAX_SACRIFICE = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(sacrificeCount >= MAX_SACRIFICE)
        {
            print("PLAYER VICTORY");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("ENTER COLLISION");
        if (collision.gameObject.tag == sacrificePrefab.tag)
        {
            print("PLAYER COLLIDE WITH SACRIFICE");
            sacrificeCount++;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ENTER TRIGGER");
        if (collision.gameObject.tag == cloudPrefab.tag)
        {
            print("PLAYER COLLIDE WITH SPAWNER");
            Destroy(collision.gameObject);
        }
    }
}
