using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool isDead = false;
    
    SpriteRenderer rend;
    public SceneManagerScript scenManager;
    
    
    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<SpriteRenderer>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
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
    IEnumerator WaitTilLoadingScene()
    {
        yield return new WaitForSeconds(scenManager.timeToWaitBeforeTransition);
        print("Ay");
        scenManager.ReloadScene();
    }
    public void Die()
    {
        print("Dead");
        gameObject.tag = "Dead";
        isDead = true;
        StartCoroutine(FadeOut());
        StartCoroutine(WaitTilLoadingScene());
        //Do SceneManager Kind of Things
    }
}
