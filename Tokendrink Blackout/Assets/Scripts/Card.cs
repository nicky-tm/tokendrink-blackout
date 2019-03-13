using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public int generation;
    public float progress;
    Vector3 targetPosition;
    float moveSpeed = 0.1f;
    public int index;

    WifiFill wifi;
    public float speed;


    private void Awake(){
        CardPositions.AddPosition(index, transform.position);
        GameManager.AddCard(index, this);

        wifi = GetComponentInChildren<WifiFill>();
        
        targetPosition = transform.position;
    }
    private void LateUpdate(){
        targetPosition = GameManager.GetTargetPosition(generation);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed);

        float scaledSpeed = speed / GameManager.HighestSpeed;
        wifi.value = Mathf.Clamp01(scaledSpeed);
    }

}