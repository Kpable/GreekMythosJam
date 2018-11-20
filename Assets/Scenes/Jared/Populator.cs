using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populator : MonoBehaviour {

    public GameObject fogSpawnerPrefab;
    public GameObject LeftBound, RightBound, LowBound, HighBound;
    private Vector2 leftBound, rightBound, lowBound, highBound;
    public int fogSpawnerCount;

    // Use this for initialization
    void Start () {
        leftBound = LeftBound.GetComponent<Transform>().position;
        rightBound = RightBound.GetComponent<Transform>().position;
        lowBound = LowBound.GetComponent<Transform>().position;
        highBound = HighBound.GetComponent<Transform>().position;

        for (int i = 0; i < fogSpawnerCount; i++)
        {
            var fogSpawner = (GameObject) Instantiate(
                fogSpawnerPrefab,
                new Vector3(Random.Range(Camera.main.ScreenToViewportPoint(leftBound).x, Camera.main.ScreenToViewportPoint(rightBound).x),
                            Random.Range(Camera.main.ScreenToViewportPoint(lowBound).y, Camera.main.ScreenToViewportPoint(highBound).y)),
                transform.rotation
            );
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
