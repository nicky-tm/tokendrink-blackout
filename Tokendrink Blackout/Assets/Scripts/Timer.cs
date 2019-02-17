using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeftSec = 60;
    public int timeLeftMill = 0;
    public string timeLeftSeco = "60";
    public string timeLeftMilli = "00";
    public Text countdownSec;
    public Text countdownMill;

    void Update() {
        countdownSec.text = (timeLeftSeco);
        countdownMill.text = (timeLeftMilli);

        if (Input.GetKeyUp(KeyCode.X))
        {
            StartCoroutine("countdown");
        }

        if (timeLeftSec <= 0) {
            StopCoroutine("countdown");
            countdownSec.text = "";
            countdownMill.text = "";
        }
    }

    IEnumerator countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01F);
            timeLeftMill--;

            if (timeLeftMill <= 0)
            {
                timeLeftMill = 59;
                timeLeftSec--;
            }

            if (timeLeftSec <= 9)
            {
                timeLeftSeco = "0" + timeLeftSec;
            } else {
                timeLeftSeco = "" + timeLeftSec;
            }

            if (timeLeftMill <= 9)
            {
                timeLeftMilli = "0" + timeLeftMill;
            } else {
                timeLeftMilli = "" + timeLeftMill;
            }
        }
    }
}
