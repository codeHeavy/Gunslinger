using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float health = 100;
    public bool hasWeapon = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void takeDamage(float dmg)
    {
        health -= dmg;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gun")
        {
            //Debug.Log(newGun.name);
            if (Input.GetButtonDown("Fire2"))
            {
                if (hasWeapon)
                {
                    Weapon currentGun = gameObject.GetComponentInChildren<Weapon>();
                    collision.gameObject.GetComponent<Weapon>().equiped = true;
                    collision.gameObject.GetComponent<Weapon>().changingWeapon = true;  // to avoid instant de-equip
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;    // to stop constant collision check with player
                    collision.gameObject.transform.SetParent(this.gameObject.transform);
                    collision.gameObject.GetComponent<Weapon>().resetPosition();
                    //collision.gameObject.SetActive(false);
                    currentGun.dropWeapon();
                    hasWeapon = true;
                    
                }
                else
                {
                    //Debug.Log("Pickup gun");
                    collision.gameObject.GetComponent<Weapon>().equiped = true;
                    collision.gameObject.GetComponent<Weapon>().changingWeapon = true;  // to avoid instant de-equip
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;    // to stop constant collision check with player
                    collision.gameObject.transform.SetParent(this.gameObject.transform);
                    collision.gameObject.GetComponent<Weapon>().resetPosition();
                    //collision.gameObject.SetActive(false);
                    hasWeapon = true;
                }
            }
        }
    }
}
