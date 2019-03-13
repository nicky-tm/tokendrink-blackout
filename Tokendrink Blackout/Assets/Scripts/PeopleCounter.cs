using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PeopleCounter : MonoBehaviour
{
    public int countPlus = 0;
    public Text count;

    void Update()
    {
        count.text = (countPlus.ToString());
        if (Input.GetKeyUp(KeyCode.X))
        {
            countPlus++;
        }
    }
}
