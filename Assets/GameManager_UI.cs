using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_UI : MonoBehaviour {

    public GameManager_Player playerManager;
    private Text[] lines;

    // Use this for initialization
    void Start () {
        lines = GetComponentsInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        lines[0].text = "Sacrifices Following: " + playerManager.sacrificeCount;
        lines[1].text = "Follower Capacity: " + playerManager.sacrificeLimit;
        lines[2].text = "Sacrifices Saved: " + playerManager.sacrificesSaved;
    }
}
