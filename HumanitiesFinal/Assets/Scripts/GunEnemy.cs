using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour {

    public float shotDelay;
    public GameObject bullet;
    public bool facingRight;
    private float shotTimer;
    private TimeManager timeManager;
    // Use this for initialization
    void Start ()
    {
        shotTimer = shotDelay;
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!timeManager.isTimeStopped)
        {
            if(shotTimer < 0)
            {
                if(facingRight)
                {
                    GameObject bulletGameObject = Instantiate(bullet, new Vector3(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    bulletGameObject.GetComponent<Bullet>().spawner = gameObject;
                }
                else
                {
                    Instantiate(bullet, new Vector3(transform.position.x - 1, transform.position.y), Quaternion.identity);
                }
                shotTimer = shotDelay;
            }
            else
            {
                shotTimer -= Time.deltaTime;
            }
        }
	}
   
}
