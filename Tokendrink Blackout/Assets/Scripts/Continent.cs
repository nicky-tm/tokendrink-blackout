using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continent : MonoBehaviour
{
    public Text continent;
    public string type = "Europe";
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.LoadingData -= LoadEvent;
        GameManager.LoadingData += LoadEvent;
    }

    // Update is called once per frame
    void Update()
    {
        continent.text = ("Now attacking " + type);
    }

    void LoadEvent (string value) {
        this.type = value;
    }
}
