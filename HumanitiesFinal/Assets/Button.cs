using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject pillar;
    private bool pressedButton;
    public float distance;
    private bool calledOnce = false;
	// Use this for initialization
	void Start () {
        pressedButton = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pressedButton && !calledOnce)
        {
            StartCoroutine(MoveDown());
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision");
        if(collision.gameObject.tag == "KidController")
        {
            pressedButton = true;
        }
    }
    IEnumerator MoveDown()
    {
        int x = 0;
        while(x < distance)
        {
            yield return new WaitForEndOfFrame();
            pillar.transform.position -= new Vector3(0, 1 * Time.deltaTime);
            x++;
        }
    }
}
