using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour {

    public PlayerController playerController;
    bool calledRight;
	// Use this for initialization
	void Start ()
    {
        playerController = GetComponentInParent<PlayerController>();
        print(transform.position.x);
        print(Mathf.Abs(transform.position.x)*-1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerController.facingRight && !calledRight)
        {
            transform.localPosition = new Vector3(transform.localPosition.x*-1, transform.localPosition.y);
            calledRight = true;
            print("called");
        }
        else if(!playerController.facingRight && calledRight)
        {
            transform.localPosition = new Vector3(transform.localPosition.x*-1, transform.localPosition.y);
            calledRight = false;
            print("called left");
        }
	}
}
