using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    public VideoClip[] clips;
    public VideoPlayer stephan;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.PlayAudio -= AudioEvent;
        GameManager.PlayAudio += AudioEvent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AudioEvent(string value)
    {

        Debug.LogWarning("Hireo: " + value);

        switch(value){
            case "startEurope":
                stephan.clip = clips[0];
                break;
            case "1":
                stephan.clip = clips[58];
                break;
            case "2":
                stephan.clip = clips[57];
                break;
            case "3":
                stephan.clip = clips[59];
                GameManager.finalBlackoutBool = true;
                break;
        }
        if (GameManager.round.ToLower() == "europe")
        {
            switch (value)
            {
                case "0":
                    stephan.clip = clips[1];
                    break;
                case "2014":
                    stephan.clip = clips[2];
                    break;
                case "2015":
                    stephan.clip = clips[3];
                    break;
                case "2016":
                    stephan.clip = clips[4];
                    break;
                case "2017":
                    stephan.clip = clips[5];
                    break;
                case "2018":
                    stephan.clip = clips[6];
                    break;
            }
        }

        if (GameManager.round.ToLower() == "asia")
        {
            switch (value)
            {
                case "0":
                    stephan.clip = clips[7];
                    break;
                case "2014":
                    stephan.clip = clips[8];
                    break;
                case "2015":
                    stephan.clip = clips[9];
                    break;
                case "2016":
                    stephan.clip = clips[10];
                    break;
                case "2017":
                    stephan.clip = clips[11];
                    break;
                case "2018":
                    stephan.clip = clips[12];
                    break;
            }
        }

        if (GameManager.round.ToLower() == "north_america")
        {
            switch (value)
            {
                case "0":
                    stephan.clip = clips[13];
                    break;
                case "2014":
                    stephan.clip = clips[14];
                    break;
                case "2015":
                    stephan.clip = clips[15];
                    break;
                case "2016":
                    stephan.clip = clips[16];
                    break;
                case "2017":
                    stephan.clip = clips[17];
                    break;
                case "2018":
                    stephan.clip = clips[18];
                    break;
            }
        }

        if (GameManager.round.ToLower() == "south_america")
        {
            switch (value)
            {
                case "0":
                    stephan.clip = clips[19];
                    break;
                case "2014":
                    stephan.clip = clips[20];
                    break;
                case "2015":
                    stephan.clip = clips[21];
                    break;
                case "2016":
                    stephan.clip = clips[22];
                    break;
                case "2017":
                    stephan.clip = clips[23];
                    break;
                case "2018":
                    stephan.clip = clips[24];
                    break;
            }
        }

        if (GameManager.round.ToLower() == "russia")
        {
            switch (value)
            {
                case "0":
                    stephan.clip = clips[25];
                    break;
                case "2014":
                    stephan.clip = clips[26];
                    break;
                case "2015":
                    stephan.clip = clips[27];
                    break;
                case "2016":
                    stephan.clip = clips[28];
                    break;
                case "2017":
                    stephan.clip = clips[29];
                    break;
                case "2018":
                    stephan.clip = clips[30];
                    break;
            }
        }

        if (GameManager.round.ToLower() == "africa")
        {
            switch (value)
            {
                case "0":
                    stephan.clip = clips[31];
                    break;
                case "2014":
                    stephan.clip = clips[32];
                    break;
                case "2015":
                    stephan.clip = clips[33];
                    break;
                case "2016":
                    stephan.clip = clips[34];
                    break;
                case "2017":
                    stephan.clip = clips[35];
                    break;
                case "2018":
                    stephan.clip = clips[36];
                    break;
            }
        }

        // if (GameManager.round.ToLower() == "antarctica")
        // {
        //     switch (value)
        //     {
        //         case "0":
        //             stephan.clip = clips[37];
        //             break;
        //         case "2014":
        //             stephan.clip = clips[38];
        //             break;
        //         case "2015":
        //             stephan.clip = clips[39];
        //             break;
        //         case "2016":
        //             stephan.clip = clips[40];
        //             break;
        //         case "2017":
        //             stephan.clip = clips[41];
        //             break;
        //         case "2018":
        //             stephan.clip = clips[42];
        //             break;
        //     }
        // }

        switch (value) {
            case "s13":
                stephan.clip = clips[51];
                break;
            case "s14":
                stephan.clip = clips[52];
                break;
            case "s17":
                stephan.clip = clips[53];
                break;
            case "s18":
                stephan.clip = clips[54];
                break;
            case "cas verploegen":
                stephan.clip = clips[43];
                break;
            case "charlaine janssen":
                stephan.clip = clips[44];
                break;
            case "cyril mengin":
                stephan.clip = clips[45];
                break;
            case "gino althof":
                stephan.clip = clips[46];
                break;
            case "lisa frissel":
                stephan.clip = clips[47];
                break;
            case "max palmans":
                stephan.clip = clips[48];
                break;
            case "mitchell multem":
                stephan.clip = clips[49];
                break;
            case "olivier sinck":
                stephan.clip = clips[50];
                break;
            case "thijs de koning":
                stephan.clip = clips[55];
                break;
            case "tom raijmakers":
                stephan.clip = clips[56];
                break;
        }
    }
}
