using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public bool isDead = false;
    public bool isSafe = false;
    public Pillar pillar;
    
    private bool calledOnce = false;
    SpriteRenderer rend;
    TimeManager timeManager;
    SceneManagerScript sceneManager;
    UiFader faderStartText;
    UiFader faderEndText;
    Teacher teacher;
    KidTouched kidTouched;
    
    // Use this for initialization
    void Start ()
    {
        
        rend = GetComponent<SpriteRenderer>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagerScript>();
        faderStartText = GameObject.FindGameObjectWithTag("StartTextManager").GetComponent<UiFader>();
        faderEndText = GameObject.FindGameObjectWithTag("EndTextManager").GetComponent<UiFader>();
        calledOnce = false;
        print("Hay");
        if (timeManager != null)
        {
            print("In here");
            StartCoroutine(timeManager.WaitBeforeGameStarts());

        }
        StartCoroutine(faderStartText.FadeInThenOut());
        if(GameObject.FindGameObjectWithTag("Teacher").GetComponent<Teacher>() != null)
            teacher = GameObject.FindGameObjectWithTag("Teacher").GetComponent<Teacher>();
        if (GameObject.FindGameObjectWithTag("KidTouched").GetComponent<Teacher>() != null)
            kidTouched = GameObject.FindGameObjectWithTag("KidTouched").GetComponent<KidTouched>();
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
        sceneManager.ReloadScene();
    }

    IEnumerator WaitTilLoadingNextScene()
    {
        yield return new WaitForSeconds(timeManager.timeForTextToAppearAfterWinCondition);
        sceneManager.LoadNextScene();
    }

    public void Die()
    {
        gameObject.tag = "Dead";
        isDead = true;
        StartCoroutine(FadeOut());
        
        //Do SceneManager Kind of Things
    }

    private void CheckRules()
    {
        if (GameObject.FindGameObjectWithTag("PlayerDeadRulesFlag") != null)
        {
            PlayerDeadRules();
        }
        else if (GameObject.FindGameObjectWithTag("PlayerSafeRuleFlag") != null)
        {
            PlayerSafeRules();
        }
        else if (GameObject.FindGameObjectWithTag("EnemyDeadRuleFlag")!= null)
        {
            EnemyDeadRules();
        }
        else if(GameObject.FindGameObjectWithTag("DadRulesFlag") != null)
        {
            DadRules();
        }
        else if(GameObject.FindGameObjectWithTag("Kid") != null)
        {
            KidRules();
        }
        else if (faderStartText.sceneWithOnlyText)
        {

            if (faderStartText.goToNextScene)
            {
                LoadNextScene();
            }
        }
    }
    private void PlayerDeadRules()
    {
        if (isDead && !calledOnce)
        {
            calledOnce = true;
            LoadNextScene();
            
        }
    }

    private void PlayerSafeRules()
    {
        if (isDead&&!calledOnce)
        {
            calledOnce = true;
            StartCoroutine(WaitTilReloadingScene());
        }
        if (isSafe && !calledOnce)
        {
            if (pillar.fadeOnSafe)
            {
                StartCoroutine(FadeOut());

            }
            calledOnce = true;
            LoadNextScene();
        }
    }

    private void EnemyDeadRules()
    {
        if (isDead && !calledOnce)
        {
            calledOnce = true;
            StartCoroutine(WaitTilReloadingScene());
        }
        if (teacher == null)
        {
            throw new Exception("Need teacher for this level");
        }
        if (teacher.killedEnemy && !calledOnce)
        {
            calledOnce = true;
            LoadNextScene();
        }
    }

    private void DadRules()
    {
        if (isDead && !calledOnce)
        {
            calledOnce = true;
            StartCoroutine(WaitTilReloadingScene());
        }
        if(GameObject.FindGameObjectWithTag("Dad") == null&&!calledOnce)
        {
            print("Done");
            calledOnce = true;
            LoadNextScene();
        }
    }

    private void KidRules()
    {
        if(kidTouched.isDone && !calledOnce)
        {
            calledOnce = true;
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        StartCoroutine(WaitTilLoadingNextScene());
        StartCoroutine(faderEndText.FadeInThenOut());
    }
}
