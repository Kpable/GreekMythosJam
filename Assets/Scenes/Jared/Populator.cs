using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populator : MonoBehaviour {

    public GameObject fogSpawnerPrefab;
    public float leftBound, rightBound, lowBound, highBound;
    public int fogSpawnerCount; 
    public Camera mainCamera;
    public BoxCollider2D safeHaven;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < fogSpawnerCount; i++)
        {
            Vector3 bounds = GetSpawnBounds();
            bounds.x = Random.Range(leftBound, rightBound);
            bounds.y = Random.Range(highBound, lowBound);

            var fogSpawner = (GameObject) Instantiate(
                fogSpawnerPrefab,
                bounds,
                transform.rotation
            );
        }
	}

    Vector3 GetSpawnBounds()
    {
        Vector3 finalBounds = new Vector3();

        finalBounds.x = Random.Range(leftBound, rightBound);
        finalBounds.y = Random.Range(highBound, lowBound);

        /*Removing due to new torchc logic
         * while(finalBounds.x <= (safeHaven.transform.position.x + safeHaven.size.x/2) &&
            finalBounds.x >= (safeHaven.transform.position.x - safeHaven.size.x / 2))
        {
            finalBounds.x = Random.Range(leftBound, rightBound);
        }

        while (finalBounds.y <= (safeHaven.transform.position.y + safeHaven.size.y / 2) &&
           finalBounds.y >= (safeHaven.transform.position.y - safeHaven.size.y / 2))
        {
            finalBounds.y = Random.Range(highBound, lowBound);
        }*/

        return finalBounds;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
