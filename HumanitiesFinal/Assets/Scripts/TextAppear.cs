using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear : MonoBehaviour
{

    private UiFader uiFader;

    public bool shouldFade;
    bool alreadyDisplayed;
    bool pressEtoFade = false;
    bool calledOnce = false;
    // Use this for initialization
    void Start()
    {
        uiFader = GetComponent<UiFader>();
        alreadyDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (pressEtoFade&&calledOnce)
        {
            uiFader.FadeOut();
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") || other.tag == "Invincible")
        {
            print(gameObject);
            if (shouldFade)
            {
                StartCoroutine(uiFader.FadeInThenOut());
            }
            else
            {
                uiFader.FadeIn();
                alreadyDisplayed = true;
                pressEtoFade = true;

            }
        }
        if (other.tag == "PanCamera")
        {
            print("HeyThats a camera");
            StartCoroutine(uiFader.FadeInThenOut());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Invincible")
        {
            uiFader.FadeOut();
            alreadyDisplayed = false;
        }
    }
}

