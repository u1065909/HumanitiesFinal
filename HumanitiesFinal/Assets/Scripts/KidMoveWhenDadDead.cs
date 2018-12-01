using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMoveWhenDadDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameObject.FindGameObjectWithTag("Dead")!= null)
        {
            transform.position += new Vector3(1 * Time.deltaTime, 0);
        }
	}
}
