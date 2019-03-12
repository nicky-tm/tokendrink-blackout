using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager {

    static Card[] cards = new Card[6];
    static List<Card> playerPositions = new List<Card>();

    public delegate void powerupEvent(string powerup, int sourceGen, int targetGen, int timeGoal, int beerGoal, int sodaGoal);
    public static event powerupEvent PowerupEvent;

    public delegate void powerupDuring(int beers, int sodas);
    public static event powerupDuring PowerupDuring;

    public delegate void loadingData(string value);
    public static event loadingData LoadingData;

    public delegate void powerupFinal(bool completed);
    public static event powerupFinal PowerupFinal;

    static float highestSpeed;
    public static float HighestSpeed {get{
        if (highestSpeed <= 0) return 1f;
        else return highestSpeed;
    }}

    public static void AddCard(int i, Card card){
        cards[i] = card;

        playerPositions.Clear();
        playerPositions.AddRange(cards);
    }

    public static void SetProgress(int generation, float progress){
        switch (generation){
            case 2018:
                cards[0].progress = progress;
                break;
            case 2017:
                cards[1].progress = progress;
                break;
            case 2016:
                cards[2].progress = progress;
                break;
            case 2015:
                cards[3].progress = progress;
                break;
            case 2014:
                cards[4].progress = progress;
                break;
            case 0:
                cards[5].progress = progress;
                break;
            default:
                Debug.LogError("Not a known generation: " + generation);
                break;
        }

        playerPositions.Clear();
        playerPositions.AddRange(cards);
        playerPositions.Sort(SortByScore);
    }

        public static void SetSpeed(int generation, float speed){
        switch (generation){
            case 2018:
                cards[0].speed = speed;
                break;
            case 2017:
                cards[1].speed = speed;
                break;
            case 2016:
                cards[2].speed = speed;
                break;
            case 2015:
                cards[3].speed = speed;
                break;
            case 2014:
                cards[4].speed = speed;
                break;
            case 0:
                cards[5].speed = speed;
                break;
            default:
                Debug.LogError("Not a known generation: " + generation);
                break;
        }

        ResetSpeed();
    }

    static int GetIndexOfPosition(Card card){
        return playerPositions.IndexOf(card);
    }

    static int SortByScore( Card c1, Card c2 ){
        return c2.progress.CompareTo(c1.progress);
    }

    public static Vector3 GetTargetPosition(int generation){
        switch (generation){
            case 2018:
                return CardPositions.positions[GetIndexOfPosition(cards[0])];
            case 2017:
                return CardPositions.positions[GetIndexOfPosition(cards[1])];
            case 2016:
                return CardPositions.positions[GetIndexOfPosition(cards[2])];
            case 2015:
                return CardPositions.positions[GetIndexOfPosition(cards[3])];
            case 2014:
                return CardPositions.positions[GetIndexOfPosition(cards[4])];
            case 0:
                return CardPositions.positions[GetIndexOfPosition(cards[5])];
            default:
                Debug.LogError("Not a known generation: " + generation);
                return Vector3.zero;
        }
    }

    static void ResetSpeed(){
            highestSpeed = 1f;
            for(int i = 0; i < cards.Length; i++){
                if(cards[i].speed > highestSpeed){
                    highestSpeed = cards[i].speed;
                }
            }
    }

    public static void StartEvent(string powerup, int sourceGen, int targetGen, int timeGoal, int beerGoal, int sodaGoal){
        PowerupEvent(powerup, sourceGen, targetGen, timeGoal, beerGoal, sodaGoal);
    }

    public static void DuringEvent(int beers, int sodas){
        PowerupDuring(beers, sodas);
    }

    public static void LoadData(string value){
        LoadingData(value);
    }

    public static void FinalEvent(bool completed) {
        PowerupFinal(completed);
    }

}
