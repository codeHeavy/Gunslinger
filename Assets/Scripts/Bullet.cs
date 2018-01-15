using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Vector3 direction;
    GameObject creator;
    public float timer = 1.0f;
    [Range(1,100)]
    public float speed = 10;
    public float damage = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        timer -= Time.deltaTime;
       
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<EnemyController>().takeDamage(damage);
        }
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }
}
