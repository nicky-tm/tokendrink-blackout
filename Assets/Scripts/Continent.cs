using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continent : MonoBehaviour
{
    public Text continent;
    public string type = "Continent";

    void Update()
    {
        type = SwitchScenes.continentValue;
        continent.text = ("Now\nattacking\n" + type);
    }
}
