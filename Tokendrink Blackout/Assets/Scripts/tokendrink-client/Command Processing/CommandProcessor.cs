using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommandProcessor {

    public static T ToDataType<T> ( string JSON ) {
        return JsonUtility.FromJson<T>(JSON);
    }

    public static void ProcessDirtyCommand ( string JSON ) {
        CommonData commonData = ToDataType<CommonData>(JSON);
        switch (commonData.type) {
            case "stats":
                ProcessData(ToDataType<PlayerData>(JSON));
                break;
            case "init":
                ProcessData(ToDataType<PowerUpInitData>(JSON));
                break;
            case "update":
                ProcessData(ToDataType<PowerUpUpdateData>(JSON));
                break;
            case "final":
                ProcessData(ToDataType<PowerUpFinalData>(JSON));
                break;
            case "load":
                ProcessData(ToDataType<GameLoadData>(JSON));
                break;
            case "trigger":
                ProcessData(ToDataType<GameTriggerData>(JSON));
                break;
            case "winner":
                ProcessData(ToDataType<GameWinnerData>(JSON));
                break;
            default:
                Debug.LogError("Couldn't process type: " + commonData.type);
                break;
        }
    }

    public static void ProcessData<T> ( T data ) {

        /// PLAYER STATS DATA
        if (data is PlayerData playerdata) {
            GameManager.SetProgress(playerdata.generation, playerdata.progress);
            GameManager.SetSpeed(playerdata.generation, playerdata.speed);
        } else if (data is PowerUpInitData powerUpInitData) {
            ThreadHelper.ExecuteInUpdate(() => {
                GameManager.StartEvent(powerUpInitData.powerup, powerUpInitData.sourceGen, powerUpInitData.targetGen, powerUpInitData.timeGoal, powerUpInitData.beerGoal, powerUpInitData.sodaGoal);
            });
        } else if (data is PowerUpUpdateData powerUpUpdataData) {
            ThreadHelper.ExecuteInUpdate(() => {
                GameManager.DuringEvent(powerUpUpdataData.beers, powerUpUpdataData.sodas);
            });
        } else if (data is GameLoadData gameLoadData) {
            ThreadHelper.ExecuteInUpdate(() => {
                GameManager.LoadData(gameLoadData.value);
            });
        } else if (data is PowerUpFinalData powerUpFinalData) {
            ThreadHelper.ExecuteInUpdate(() => {
                GameManager.FinalEvent(powerUpFinalData.completed);
            });
        } else {
            Debug.LogError("Couldn't process data type: " + data.GetType());
        }
    }

}