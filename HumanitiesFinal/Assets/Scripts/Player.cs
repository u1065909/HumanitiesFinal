using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public bool isDead = false;
    public bool isSafe = false;
    private bool calledOnce = false;
    SpriteRenderer rend;
    TimeManager timeManager;
    SceneManagerScript sceneManager;
    UiFader faderStartText;
    UiFader faderEndText;
    
    
    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<SpriteRenderer>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagerScript>();
        faderStartText = GameObject.FindGameObjectWithTag("StartTextManager").GetComponent<UiFader>();
        faderEndText = GameObject.FindGameObjectWithTag("EndTextManager").GetComponent<UiFader>();
        calledOnce = false;
        if (timeManager != null)
            StartCoroutine(timeManager.WaitBeforeGameStarts());
        StartCoroutine(faderStartText.FadeInThenOut());
        

	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckRules();
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
    IEnumerator WaitTilReloadingScene()
    {
        yield return new WaitForSeconds(timeManager.timeBetweenReloadingScene);
        print("Ay");
        sceneManager.ReloadScene();
    }

    IEnumerator WaitTilLoadingNextScene()
    {
        yield return new WaitForSeconds(timeManager.timeForTextToAppearAfterWinCondition);
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
        if (isDead && !calledOnce)
        {
            calledOnce = true;
            StartCoroutine(WaitTilLoadingNextScene());
            print("StartFadeIn");
            StartCoroutine(faderEndText.FadeInThenOut());
            
        }
    }

    private void Level2Rules()
    {
        if (isDead&&!calledOnce)
        {
            calledOnce = true;
            StartCoroutine(WaitTilReloadingScene());
        }
        if (isSafe&& !calledOnce)
        {
            calledOnce = true;
            StartCoroutine(WaitTilLoadingNextScene());
            print("SFwef");
            StartCoroutine(faderEndText.FadeInThenOut());
        }
    }

    private void Level3Rules()
    {

    }
}
