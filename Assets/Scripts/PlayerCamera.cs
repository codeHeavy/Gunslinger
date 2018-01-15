using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    GameObject playerPrefab;
	// Use this for initialization
	void Start () {
        playerPrefab = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        followPlayer();
	}

    void followPlayer()
    {
        Vector3 newPos = new Vector3(playerPrefab.transform.position.x, playerPrefab.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }
}
