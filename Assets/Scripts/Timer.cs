using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;

public class Timer : MonoBehaviour
{
    public int timeLeftSec = 60;
    public int timeLeftMill = 0;
    public string timeLeftSeco = "60";
    public string timeLeftMilli = "00";
    public Text countdownSec;
    public Text countdownMill;
    float countdownTime = 60.00f;
    string time;

    private void OnEnable () {
        countdownTime = timeLeftSec;
    }

    void Update()
    {
        if (countdownTime <= 0)
        {
            countdownSec.text = "00";
            countdownMill.text = "00";
        }
        else
        {
            countdownTime -= Time.deltaTime;
            time = countdownTime.ToString("00.00");
            countdownSec.text = time.Substring(0,2);
            countdownMill.text = time.Substring(3);
        }
    }
}