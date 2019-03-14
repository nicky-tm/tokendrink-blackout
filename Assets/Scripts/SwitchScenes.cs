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
        INTRO, COUNTDOWN, SCORE, MEMBER_COUNT, STEPHAN, WINNER, FINALBLACKOUT
    }

    public SCENE currentScene = SCENE.MEMBER_COUNT;
    SCENE lastScene;

    public Transform memberTransform, countdownTransform, scoreTransform, stephanTransform, winnerTransform, finalBlackoutTransform;

    public static string continentValue;
    public Text roundWinnerYear;
    public Text roundWinner;
    public Text finalWinner;
    public Text finalWinnerYear;

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

        GameManager.GameWinner -= WinnerEvent;
        GameManager.GameWinner += WinnerEvent;

        GameManager.FinalBlackout += FinalWinnerEvent;
        GameManager.FinalBlackout += FinalWinnerEvent;

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
            GameManager.currentScene = currentScene;
        }
    }

    void VideoEnded(VideoPlayer source)
    {
        if (currentScene == SCENE.INTRO){
            currentScene = SCENE.MEMBER_COUNT;
        }
        else if (GameManager.round.ToLower() == "europe" || GameManager.round.ToLower() == "asia" || GameManager.round.ToLower() == "north_america" || GameManager.round.ToLower() == "south_america" || GameManager.round.ToLower() == "africa")
        {
            Debug.LogWarning(GameManager.round.ToLower());
            currentScene = SCENE.WINNER;
        }
        else if (GameManager.finalBlackoutBool)
        {
            currentScene = SCENE.FINALBLACKOUT;
        }
        else    
        {
            currentScene = SCENE.SCORE;
            if (GameManager.round.ToLower() == "empty")
            {
                GameManager.round = "europe";
            }
        }
    }

    void ChangeScene()
    {
        memberTransform.gameObject.SetActive(false);
        countdownTransform.gameObject.SetActive(false);
        scoreTransform.gameObject.SetActive(false);
        stephanTransform.gameObject.SetActive(false);
        winnerTransform.gameObject.SetActive(false);
        finalBlackoutTransform.gameObject.SetActive(false);

        switch (currentScene)
        {
            case SCENE.COUNTDOWN:
                countdownTransform.gameObject.SetActive(true);
                break;
            case SCENE.SCORE:
                scoreTransform.gameObject.SetActive(true);
                GameManager.ResetPowerupHelper();
                break;
            case SCENE.MEMBER_COUNT:
                memberTransform.gameObject.SetActive(true);
                break;
            case SCENE.STEPHAN:
                stephanTransform.gameObject.SetActive(true);
                break;
            case SCENE.WINNER:
                winnerTransform.gameObject.SetActive(true);
                break;
            case SCENE.FINALBLACKOUT:
                Destroy(stephanTransform.GetComponent<Image>());
                Destroy(stephanTransform.GetComponent<VideoScript>());
                finalBlackoutTransform.gameObject.SetActive(true);
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
            continentValue = value;
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

    void WinnerEvent(int value)
    {
        if (value == 0)
        {
            roundWinnerYear.text = "old";
        }
        else
        {
            roundWinnerYear.text = "s" + value.ToString().Substring(2);
        }
        currentScene = SCENE.WINNER;

        switch (value)
        {
            case 0:
                roundWinner.color = new Color(255f, 255f, 255f);
                roundWinnerYear.color = new Color(255f, 255f, 255f);
                break;
            case 2014:
                roundWinner.color = new Color(0f, 255f, 0f);
                roundWinnerYear.color = new Color(0f, 255f, 0f);
                break;
            case 2015:
                roundWinner.color = new Color(170f, 0f, 255f);
                roundWinnerYear.color = new Color(170f, 0f, 255f);
                break;
            case 2016:
                roundWinner.color = new Color(0f, 0f, 255f);
                roundWinnerYear.color = new Color(0f, 0f, 255f);
                break;
            case 2017:
                roundWinner.color = new Color(255f, 0f, 0f);
                roundWinnerYear.color = new Color(255f, 0f, 0f);
                break;
            case 2018:
                roundWinner.color = new Color(254f, 132f, 0f);
                roundWinnerYear.color = new Color(254f, 132f, 0f);
                break;
        }
    }

    void FinalWinnerEvent(int year)
    {
        finalWinner.enabled = false;
        finalWinnerYear.enabled = true;
        if (year == 0)
        {
            finalWinnerYear.text = "old";
        }
        else
        {
            finalWinnerYear.text = "s" + year.ToString().Substring(2);
        }

        switch (year)
        {
            case 0:
                roundWinner.color = new Color(255f, 255f, 255f);
                roundWinnerYear.color = new Color(255f, 255f, 255f);
                break;
            case 2014:
                roundWinner.color = new Color(0f, 255f, 0f);
                roundWinnerYear.color = new Color(0f, 255f, 0f);
                break;
            case 2015:
                roundWinner.color = new Color(170f, 0f, 255f);
                roundWinnerYear.color = new Color(170f, 0f, 255f);
                break;
            case 2016:
                roundWinner.color = new Color(0f, 0f, 255f);
                roundWinnerYear.color = new Color(0f, 0f, 255f);
                break;
            case 2017:
                roundWinner.color = new Color(255f, 0f, 0f);
                roundWinnerYear.color = new Color(255f, 0f, 0f);
                break;
            case 2018:
                roundWinner.color = new Color(254f, 132f, 0f);
                roundWinnerYear.color = new Color(254f, 132f, 0f);
                break;
        }
    }

    void AudioEvent(string value)
    {
        Invoke("play", 0.25f);
    }

    void play()
    {
        currentScene = SCENE.STEPHAN;
    }
}
