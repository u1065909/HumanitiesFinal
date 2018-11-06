using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public bool isDead = false;
    
    SpriteRenderer rend;
    public SceneManagerScript sceneManager;
    
    
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
        yield return new WaitForSeconds(sceneManager.timeToWaitBeforeTransition);
        print("Ay");
        sceneManager.ReloadScene();
    }

    IEnumerator WaitTilLoadingNextScene()
    {
        yield return new WaitForSeconds(sceneManager.timeToWaitBeforeTransition);
        print("Ay");
        sceneManager.LoadNextScene();
    }

    public void Die()
    {
        print("Dead");
        gameObject.tag = "Dead";
        isDead = true;
        StartCoroutine(FadeOut());
        
        //Do SceneManager Kind of Things
    }

    private void CheckRules()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Level1Rules();
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Level2Rules();
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Level3Rules();
        }
    }
    private void Level1Rules()
    {
        if (isDead)
        {
            StartCoroutine(WaitTilLoadingNextScene());
        }
    }

    private void Level2Rules()
    {
        
    }

    private void Level3Rules()
    {

    }
}
