using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public GameObject spawner;
    public GunEnemy owner;
    public GameObject player;
    public float timeAlive;
	// Use this for initialization
	void Start ()
    {
        owner = spawner.GetComponent<GunEnemy>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitToDie());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (owner.facingRight)
        {
            transform.position += new Vector3(speed, 0,0);
        }
            
        else
        {
            transform.position -= new Vector3(speed, 0,0);

        }

	}
    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
            player.GetComponent<Player>().Die();
        }
        if (collision.gameObject.tag == "Wall")
        {
            print("Sdfwef");
            Destroy(gameObject);
        }


    }
}
