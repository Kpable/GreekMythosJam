using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSpawn : MonoBehaviour
{

    public GameObject cloudPrefab;

    private bool isEnabled;
    private bool isSpawned;
    private List<GameObject> clouds;

    // Use this for initialization
    void Start()
    {
        clouds = new List<GameObject>();
        isEnabled = true;
        isSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            if (isSpawned == false)
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        for (int i = 0; i < 30; i++)
        {
            var cloud = (GameObject)Instantiate(
                cloudPrefab,
                transform.position + new Vector3(Random.insideUnitCircle.x + .5f, Random.insideUnitCircle.y +.5f, 0),
                transform.rotation,
                this.transform
            );

            cloud.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, Random.value);
            cloud.GetComponent<DistanceJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            cloud.GetComponent<DistanceJoint2D>().distance = 3 * Random.value;

            clouds.Add(cloud);
            print("Adding cloud: " + clouds.Count.ToString());
        }

        isSpawned = true;
    }

    public void Appear()
    {
        isEnabled = true;
    }

}
