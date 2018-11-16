using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_UI : MonoBehaviour {

    public GameManager_Player playerManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Text>().text = "Sacrifices Found: " + playerManager.sacrificeCount;
	}
}
