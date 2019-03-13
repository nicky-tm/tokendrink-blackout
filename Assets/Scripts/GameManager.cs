using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager {

    static Card[] cards = new Card[6];
    public static List<Card> playerPositions = new List<Card>();
    public static string round = "empty";

    public delegate void powerupEvent(string powerup, int sourceGen, int targetGen, int timeGoal, int beerGoal, int sodaGoal);
    public static event powerupEvent PowerupEvent;

    public delegate void powerupDuring(int beers, int sodas);
    public static event powerupDuring PowerupDuring;

    public delegate void loadingData(string value);
    public static event loadingData LoadingData;

    public delegate void powerupFinal(bool completed);
    public static event powerupFinal PowerupFinal;

    public delegate void triggerContinent(string value);
    public static event triggerContinent TriggerContinent;

    public delegate void memberCount(int value);
    public static event memberCount MemberCount;

    public delegate void playAudio(string value);
    public static event playAudio PlayAudio;

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

    public static void SetRound(string value){
        round = value;
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

        if (playerPositions.Count == 6) {
            playerPositions.Sort(SortByScore);
        }
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
        if (playerPositions.IndexOf(card) < 0) {
            Debug.LogError("ERROR");
            return -1;
        } else {
            return playerPositions.IndexOf(card);
        }

    }

    static int SortByScore( Card c1, Card c2 ){
        return c2.progress.CompareTo(c1.progress);
    }

    public static Vector3 GetTargetPosition(int generation){
        switch (generation){
            case 2018:
                if (cards[0] == null) return Vector3.zero;
                if (GetIndexOfPosition(cards[0]) == -1) return Vector3.zero;
                if (CardPositions.positions[GetIndexOfPosition(cards[0])] == null) return Vector3.zero;

                return CardPositions.positions[GetIndexOfPosition(cards[0])];
            case 2017:
                if (cards[1] == null) return Vector3.zero;
                if (GetIndexOfPosition(cards[1]) == -1) return Vector3.zero;
                if (CardPositions.positions[GetIndexOfPosition(cards[1])] == null) return Vector3.zero;

                return CardPositions.positions[GetIndexOfPosition(cards[1])];
            case 2016:
                if (cards[2] == null) return Vector3.zero;
                if (GetIndexOfPosition(cards[2]) == -1) return Vector3.zero;
                if (CardPositions.positions[GetIndexOfPosition(cards[2])] == null) return Vector3.zero;

                return CardPositions.positions[GetIndexOfPosition(cards[2])];
            case 2015:
                if (cards[3] == null) return Vector3.zero;
                if (GetIndexOfPosition(cards[3]) == -1) return Vector3.zero;
                if (CardPositions.positions[GetIndexOfPosition(cards[3])] == null) return Vector3.zero;

                return CardPositions.positions[GetIndexOfPosition(cards[3])];
            case 2014:
                if (cards[4] == null) return Vector3.zero;
                if (GetIndexOfPosition(cards[4]) == -1) return Vector3.zero;
                if (CardPositions.positions[GetIndexOfPosition(cards[4])] == null) return Vector3.zero;

                return CardPositions.positions[GetIndexOfPosition(cards[4])];
            case 0:
                if (cards[5] == null) return Vector3.zero;
                if (GetIndexOfPosition(cards[5]) == -1) return Vector3.zero;
                if (CardPositions.positions[GetIndexOfPosition(cards[5])] == null) return Vector3.zero;

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
        round = value;
    }

    public static void FinalEvent(bool completed) {
        PowerupFinal(completed);
    }

    public static void TriggerEvent(string value) {
        TriggerContinent(value);

        if (round == "europe"){
            PlayAudio("startEurope");
        }
    }

    public static void CountEvent(int value) {
        MemberCount(value);
    }

    public static void AudioEvent(string value) {
        PlayAudio(value);
    }

}
