using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class GetStats : MonoBehaviour
{
    public Character stats;
    void Update()
    {
        GetComponent<Text>().text = (stats.CurrentAtk).ToString() + "\n" + 
                                    (stats.MaxHp).ToString() + "\n" + 
                                    (stats.stats.CD * stats.PercentCD / 100).ToString();
    }
}
