using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    bool countdownEvent = false;
    bool scoreboardEvent = false;
    bool countEvent = false;

    void Start(){
        GameManager.LoadingData -= LoadEvent;
        GameManager.LoadingData += LoadEvent;

        GameManager.TriggerContinent -= TriggerEvent;
        GameManager.TriggerContinent += TriggerEvent;

        GameManager.MemberCount -= CountEvent;
        GameManager.MemberCount += CountEvent;
    }
    
    void Update()
    {
        // if (Input.GetKeyUp(KeyCode.Alpha0))
        // {
        //    StartCoroutine(LoadPeopleCounter());
        // } else if (Input.GetKeyUp(KeyCode.Alpha1))
        // {
        //    StartCoroutine(LoadCountdown());
        // } else if (Input.GetKeyUp(KeyCode.Alpha2))
        // {
        //    StartCoroutine(LoadCurrentScore());
        // }

        if (countEvent == true)
        {
           StartCoroutine(LoadPeopleCounter());
           countEvent = false;
        } else if (countdownEvent == true)
        {
           StartCoroutine(LoadCountdown());
           countdownEvent = false;
        } else if (scoreboardEvent == true)
        {
           StartCoroutine(LoadCurrentScore());
           scoreboardEvent = false;
        }
    }

    void LoadEvent (string value) {
        if (value != "intro" && value != "end") {
            countdownEvent = true;
        }
    }

    void TriggerEvent (string value) {
        if (value == "battle") {
            scoreboardEvent = true;
        }
    }

    void CountEvent (int value) {
        countEvent = true;
    }

    IEnumerator LoadPeopleCounter()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("PeopleCounter");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadCountdown()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Countdown");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadCurrentScore()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CurrentScore");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
