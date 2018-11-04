using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiPolarEnemy : MonoBehaviour {

    public Transform target;
    public float speed;
    public float range;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(target.position, transform.position) < range)
        {
            ChasePlayer();
        }
        
	}

    private void ChasePlayer()
    {
        if(target.position.x > transform.position.x)
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if(target.position.x < transform.position.x)
        {
            transform.position -= new Vector3(speed, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Gotcha");
            collision.gameObject.GetComponent<Player>().Die();
            speed = 0;
        }
    }
}
