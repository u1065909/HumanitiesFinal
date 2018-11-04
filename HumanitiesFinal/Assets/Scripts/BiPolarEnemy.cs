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
	// Use this for initialization
	void Start ()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(target.position, transform.position) < range)
        {
            ChasePlayer();
        }
        if(rend.material.color.a < 0)
        {
            Destroy(gameObject);
        }
        
	}

    private void ChasePlayer()
    {
        if(target.position.x > transform.position.x)
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if(target.position.x < transform.position.x )
        {
            transform.position -= new Vector3(speed, 0, 0);
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
            int teacherLength = collision.gameObject.GetComponent<Player>().teachers.Count;
            print("Gotcha");
            if(teacherLength == 0)
            {
                collision.gameObject.GetComponent<Player>().Die();
            }
            else
            {
                collision.gameObject.GetComponent<Player>().teachers.RemoveAt(teacherLength - 1);
                isDead = true;
                StartCoroutine(FadeOut());
            }
            
            speed = 0;
        }
    }
}
