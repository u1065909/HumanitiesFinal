using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFader : MonoBehaviour {

    public CanvasGroup textCanvasGroup;
    public float timeForTextToFadeIn;
    public float timeForTextToFadeOut;
    //If true then this scene only has text, this being the first of possibly multiple texts
    public bool sceneWithOnlyText;
    //This only applies if sceneWithOnlyText is true, determines which text will appear last before moving on
    public bool lastTextOnScreen;
    public bool goToNextScene;
    private bool textFinished = false;

    public float timeForTextToAppear;
	public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(textCanvasGroup, textCanvasGroup.alpha, 1,timeForTextToFadeIn));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(textCanvasGroup, textCanvasGroup.alpha, 0, timeForTextToFadeOut));
    }
    public IEnumerator FadeCanvasGroup(CanvasGroup canvas,float start,float end,float timeForFade)
    {
        float timeStarted = Time.time;
        float timeSinceStarted = Time.time - timeStarted;
        float percentComplete = timeSinceStarted / timeForFade;
        while (true)
        {
            timeSinceStarted = Time.time - timeStarted;
            percentComplete = timeSinceStarted / timeForFade;
            float currentValue = Mathf.Lerp(start, end, percentComplete);
            canvas.alpha = currentValue;
            if (percentComplete >= 1)
                break;
            yield return new WaitForEndOfFrame();
        }
        if (textFinished)
        {
            goToNextScene = true;
        }
    }
    public IEnumerator FadeInThenOut()
    {
        FadeIn();
        yield return new WaitForSeconds(timeForTextToAppear);
        if (lastTextOnScreen)
        {
            textFinished = true;
        }
        FadeOut();
    }
}
