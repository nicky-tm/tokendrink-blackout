using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
           StartCoroutine(LoadPeopleCounter());
        } else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
           StartCoroutine(LoadCountdown());
        } else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
           StartCoroutine(LoadCurrentScore());
        }
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
