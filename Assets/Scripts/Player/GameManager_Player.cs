using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Player : MonoBehaviour {

    // Game Objects
    public Rigidbody2D playerBody;
    public GameObject sacrificePrefab;
    public GameObject cloudPrefab;
    public GameObject spawnerPrefab;

    // Player Stats
    public int sacrificeCount = 0;
    public int sacrificeLimit;
    public int sacrificesSaved = 0;
    public int torchCount = 0;

    // Constants
    public int MAX_SACRIFICE = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(sacrificesSaved >= MAX_SACRIFICE)
        {
            print("PLAYER VICTORY");
            SceneManager.LoadScene("End Game");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ENTER TRIGGER");

        if (collision.gameObject.tag == sacrificePrefab.tag && sacrificeCount < sacrificeLimit)
        {
            print("PLAYER COLLIDE WITH SACRIFICE");
            sacrificeCount++;
            Destroy(collision.gameObject);
        }
        else if (cloudPrefab != null && (collision.gameObject.tag == cloudPrefab.tag))
        {
            print("PLAYER COLLIDE WITH SPAWNER");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Haven")
        {
            if(sacrificeCount > 0)
            {
                sacrificesSaved += sacrificeCount;
                sacrificeLimit++;
                sacrificeCount = 0;
            }
        }
    }
}
