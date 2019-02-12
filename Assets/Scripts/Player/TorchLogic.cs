using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLogic : MonoBehaviour {

    public GameObject cloudPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Create torch logic
        if (cloudPrefab != null && (collision.gameObject.tag == cloudPrefab.tag))
        {
            //print("TORCH COLLIDE WITH CLOUD");
            // TODO: Cast as FogSpawner and call the Disappear
            collision.gameObject.GetComponent<FogSpawn>().Disappear();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }
}
