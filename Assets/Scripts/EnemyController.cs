using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    float health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            death();
        }
	}

    public void takeDamage(float dmg)
    {
        health -= dmg;
    }

    void death()
    {
        Destroy(this.gameObject);
        Camera.main.gameObject.GetComponent<CameraShake>().shakeDuration = 1;
    }
}
