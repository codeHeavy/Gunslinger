using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
  
    public GameObject bulletPrefab;
    float timeToFire = 0;
    [Range(1,100)]
    public float fireRate = 1;

    Rigidbody2D weaponRb;
    [SerializeField]
    public bool equiped = false;

    public bool changingWeapon = false;
    public float changeTime = 0.5f;


    // Use this for initialization
    void Start () {
        weaponRb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (changingWeapon)
        {
            changeTime -= Time.deltaTime;
            if (changeTime <= 0)
                changingWeapon = false;
        }

        if (equiped && Input.GetKeyDown(KeyCode.G) && changeTime <= 0)
        {
            dropWeapon();
        }
       
        if (Input.GetButton("Fire1") && Time.time > timeToFire && equiped)
        {
            timeToFire = Time.time + 1 / fireRate;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        Camera.main.gameObject.GetComponent<CameraShake>().shakeDuration = 0;
    }

    public void dropWeapon()
    {
        transform.parent.gameObject.GetComponent<PlayerController>().hasWeapon = false;
        transform.parent = null;
        equiped = false;
        changeTime = 0.5f;
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    public void resetPosition()
    {
        transform.localPosition = new Vector3(0,0.3f,0);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
