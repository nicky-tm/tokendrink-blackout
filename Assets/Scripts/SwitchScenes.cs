using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SwitchScenes : MonoBehaviour
{
    public enum SCENE
    {
        COUNTDOWN, SCORE, MEMBER_COUNT, STEPHAN
    }

    public SCENE currentScene = SCENE.MEMBER_COUNT;
    SCENE lastScene;

    public Transform memberTransform, countdownTransform, scoreTransform, stephanTransform;

    void Start()
    {
        GameManager.LoadingData -= LoadEvent;
        GameManager.LoadingData += LoadEvent;

        GameManager.TriggerContinent -= TriggerEvent;
        GameManager.TriggerContinent += TriggerEvent;

        GameManager.MemberCount -= CountEvent;
        GameManager.MemberCount += CountEvent;

        GameManager.PlayAudio -= AudioEvent;
        GameManager.PlayAudio += AudioEvent;

        stephanTransform.GetComponent<VideoPlayer>().loopPointReached -= VideoEnded;
        stephanTransform.GetComponent<VideoPlayer>().loopPointReached += VideoEnded;

        lastScene = currentScene;
    }

    void Update()
    {
        if (currentScene != lastScene)
        {
            ChangeScene();
            lastScene = currentScene;
        }
    }

    void VideoEnded(VideoPlayer source){
        currentScene = SCENE.SCORE;
    }

    void ChangeScene()
    {
        memberTransform.gameObject.SetActive(false);
        countdownTransform.gameObject.SetActive(false);
        scoreTransform.gameObject.SetActive(false);
        stephanTransform.gameObject.SetActive(false);

        switch (currentScene)
        {
            case SCENE.COUNTDOWN:
                countdownTransform.gameObject.SetActive(true);
                break;
            case SCENE.SCORE:
                scoreTransform.gameObject.SetActive(true);
                break;
            case SCENE.MEMBER_COUNT:
                memberTransform.gameObject.SetActive(true);
                break;
            case SCENE.STEPHAN:
                stephanTransform.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void LoadEvent(string value)
    {
        if (value.ToLower() != "intro" && value.ToLower() != "end")
        {
            currentScene = SCENE.COUNTDOWN;
        }
    }

    void TriggerEvent(string value)
    {
        if (value.ToLower() == "battle")
        {
            currentScene = SCENE.SCORE;
        }
    }

    void CountEvent(int value)
    {
        currentScene = SCENE.MEMBER_COUNT;
    }

    void AudioEvent(string value) {
        Invoke("play", 0.25f);
        
    }

    void play (){
        currentScene = SCENE.STEPHAN;
    }
}
