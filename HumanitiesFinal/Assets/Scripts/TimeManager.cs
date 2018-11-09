using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public float timeForTextToAppear;
    public float timeForTextToAppearAfterWinCondition;
    public float timeBetweenReloadingScene;

    /// <summary>
    /// Doesn't actually stop time, this waits for timeForTextToAppear amount of seconds then objects can start doing there stuff look at 'WaitBeforeGameStarts()' IEnumerator for more details
    /// </summary>
    public bool isTimeStopped = false;
    // Use this for initialization

    void Start () {

	}
    public IEnumerator WaitBeforeGameStarts()
    {
        isTimeStopped = true;
        
        yield return new WaitForSeconds(timeForTextToAppear);
        isTimeStopped = false;
        print("TimeAfter" + Time.timeScale);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
