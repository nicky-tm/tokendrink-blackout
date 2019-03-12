using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiFill : MonoBehaviour
{
    Transform wifiFill;
    float minSize = 0.25f;
    float maxSize = 1f;
    [Range(0,1)]
    public float value = 0.5f;

    void Start()
    {
        wifiFill = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        wifiFill.transform.localScale = Vector3.one*Mathf.Lerp(minSize,maxSize,value);
    }
}
