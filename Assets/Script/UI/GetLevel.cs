using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLevel : MonoBehaviour
{
    public Character stats;
    void Update()
    {
        GetComponent<Text>().text = "LVL" + " " + stats.Level.ToString();
    }
}
