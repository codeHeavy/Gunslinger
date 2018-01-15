using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    bool moving = false;
    [Range(0,10)]
    public float speed = 5.0f;

    Camera cam;
    Rigidbody2D playerRigidbody;
    Vector3 mousePos;
	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent <Rigidbody2D>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movement();
        rotatePlayer();

    }

    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.fixedDeltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.fixedDeltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime, Space.World);
            moving = true;
        }
        if(Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.S) != true && Input.GetKey(KeyCode.D) != true)
        {
            moving = false ;
        }
    }

    void rotatePlayer()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z - cam.transform.position.z));
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
