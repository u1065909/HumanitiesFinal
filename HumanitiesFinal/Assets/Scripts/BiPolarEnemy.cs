using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiPolarEnemy : MonoBehaviour {

    public Transform target;
    public float speed;
    public float range;
    private SpriteRenderer rend;
    private bool isDead = false;
    private TimeManager timeManager;
	// Use this for initialization
	void Start ()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!timeManager.isTimeStopped)
        {
            if (target.gameObject.GetComponent<Player>().isDead || target.gameObject.GetComponent<Player>().isSafe)
                Destroy(this);
            if (Vector3.Distance(target.position, transform.position) < range)
            {
                ChasePlayer();
            }
            if(rend.material.color.a < 0)
            {
                Destroy(gameObject);
            }
        }
        
	}

    private void ChasePlayer()
    {
        if(target.position.x > transform.position.x)
        {
            transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
        }
        if(target.position.x < transform.position.x )
        {
            transform.position -= new Vector3(speed*Time.deltaTime, 0, 0);
        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1; f > -.05f; f -= .05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(.05f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"&& !isDead)
        {
            collision.gameObject.GetComponent<Player>().Die();
            speed = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Sdfwe");
        if (collision.gameObject.tag == "Teacher")
        {
            gameObject.tag = "Dead";
            collision.gameObject.GetComponent<Teacher>().killedEnemy = true;
            isDead = true;
            speed = 0;
            StartCoroutine(FadeOut());
        }
    }
}
