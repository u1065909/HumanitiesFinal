using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDad : MonoBehaviour {

    public bool fade;
    public bool walkRight;
    SpriteRenderer rend;
    public MeshRenderer text;
    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = text.material.color;
        c.a = 0;
        text.material.color = c;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(FadeIn());
            Leave();
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
    IEnumerator FadeIn()
    {
        for (float f = 0; f < 1f; f += .05f)
        {
            Color c = text.material.color;
            c.a = f;
            text.material.color = c;
            yield return new WaitForSeconds(.05f);
        }

    }
    IEnumerator Walk()
    {

        while (true)
        {

            if (walkRight)
            {
                transform.position += new Vector3(2f * Time.deltaTime, 0);
            }
            else
            {
                transform.position -= new Vector3(2f * Time.deltaTime, 0);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    private void Leave()
    {
        gameObject.tag = "Teacher";
        if (!fade)
        {
            StartCoroutine(Walk());
        }
        else
        {
            StartCoroutine(FadeOut());
        }

        
    }
}
