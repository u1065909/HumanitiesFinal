using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFader : MonoBehaviour {

    public CanvasGroup textCanvasGroup;
    public float timeForTextToFadeIn;
    public float timeForTextToFadeOut;

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
    }
    public IEnumerator FadeInThenOut()
    {
        FadeIn();
        yield return new WaitForSeconds(timeForTextToAppear);
        FadeOut();
    }
}
