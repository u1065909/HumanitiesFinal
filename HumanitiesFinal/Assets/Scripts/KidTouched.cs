using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidTouched : MonoBehaviour {

    public bool isDone;
	// Use this for initialization
	void Start () {
        isDone = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "Kid")
        {
            print("D");
            isDone = true;
        }
    }
}
