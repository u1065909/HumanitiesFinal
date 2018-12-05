using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour {

    public Transform target;
    public float timeToWaitThenRun;
    public float speed;
    bool calledRight;
    private TimeManager timeManager;
    // Use this for initialization
    void Start ()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!timeManager.isTimeStopped)
        {
            timeToWaitThenRun -= Time.deltaTime;
            if(timeToWaitThenRun < 0 && transform.position.x < target.position.x)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0);
            }

        }
	}
}
