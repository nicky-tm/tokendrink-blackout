using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public int generation;
    public float progress = 0;
    Vector3 targetPosition;
    float moveSpeed = 0.1f;
    public int index;

    WifiFill wifi;
    public float speed;


    private void Start(){
        CardPositions.AddPosition(index, transform.localPosition);
        GameManager.AddCard(index, this);

        wifi = GetComponentInChildren<WifiFill>();
        
        targetPosition = transform.localPosition;
    }
    private void Update(){
        targetPosition = GameManager.GetTargetPosition(generation);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, moveSpeed);

        float scaledSpeed = speed / GameManager.HighestSpeed;
        wifi.value = Mathf.Clamp01(scaledSpeed);

        Debug.Log(GameManager.playerPositions.Count);
    }

}