﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour {

    public bool fadeOnSafe = false;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().isSafe = true;
        }
    }
}
