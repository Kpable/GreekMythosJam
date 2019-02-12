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
    GameObject followerChild;

    // Player Stats
    public int torchCount = 0;

    // Constants
    public int MAX_SACRIFICE = 10;

    // Sacrifices
    List<NpcMovement> followers;
    public int sacrificeCount = 0;
    public int sacrificeLimit;
    public int sacrificesSaved = 0;

    // Use this for initialization
    void Start () {
        followers = new List<NpcMovement>();
        followerChild = transform.GetChild(0).gameObject;
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

        if (collision.gameObject.tag == sacrificePrefab.tag )//&& sacrificeCount < sacrificeLimit)
        {
            NpcMovement sacrificeMover = collision.gameObject.GetComponent<NpcMovement>();
            if (sacrificeMover && !sacrificeMover.collected)
            {
                print("PLAYER COLLIDE WITH SACRIFICE");
                AddFollower(sacrificeMover);
            }

        }
        else if (cloudPrefab != null && (collision.gameObject.tag == cloudPrefab.tag))
        {
            print("PLAYER COLLIDE WITH SPAWNER");
            //Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Haven")
        {
            if(sacrificeCount > 0)
            {
                sacrificesSaved += sacrificeCount;
                sacrificeLimit++;
                sacrificeCount = 0;
                foreach( NpcMovement sacrifice in followers)
                {
                    Destroy(sacrifice.gameObject);
                }
                followers.Clear();
            }
        }
    }

    private void AddFollower(NpcMovement sacrifice)
    {
        sacrificeCount++;
        sacrifice.following = true;
        sacrifice.collected = true;
        if(followers.Count != 0)
        {
            sacrifice.SetTarget(followers[followers.Count - 1].followerChild);
        }
        else
        {
            sacrifice.SetTarget(followerChild);
        }
        followers.Add(sacrifice);

    }
}
