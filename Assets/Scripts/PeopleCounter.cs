using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PeopleCounter : MonoBehaviour
{
    public Text count;
    string Count = "0";

    void Start() {
        GameManager.MemberCount -= CountEvent;
        GameManager.MemberCount += CountEvent;
    }

    void Update() {
        count.text = (Count);
    }
    
    void CountEvent(int value) {
        this.Count = value.ToString();
    }
}