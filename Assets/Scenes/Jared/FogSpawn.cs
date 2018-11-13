using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSpawn : MonoBehaviour {

    public GameObject cloudPrefab;
    
	// Use this for initialization
	void Start () {
		for(int i = 0; i < 30; i++)
        {
            var cloud = (GameObject) Instantiate(
                cloudPrefab,
                transform.position + new Vector3(Random.insideUnitCircle.x,Random.insideUnitCircle.y, 0),
                transform.rotation
            );

            cloud.GetComponent<SpriteRenderer>().color = new Color(255,255,255,Random.value+.5f);
            cloud.GetComponent<DistanceJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            cloud.GetComponent<DistanceJoint2D>().distance = 3 * Random.value;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
