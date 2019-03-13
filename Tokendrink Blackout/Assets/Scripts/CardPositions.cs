using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardPositions {

    public static Vector3[] positions = new Vector3[6];

    public static void AddPosition(int i, Vector3 pos){
        positions[i] = pos;
    }

}
