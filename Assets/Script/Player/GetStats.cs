using UnityEngine;
using UnityEngine.UI;

public class GetStats : MonoBehaviour
{
    public Character stats;
    void Update()
    {
        GetComponent<Text>().text = (stats.CurrentAtk).ToString("00") + "\n" + 
                                    (stats.MaxHp).ToString("00") + "\n" + 
                                    (stats.stats.CD * stats.PercentCD / 100).ToString("F1") + " secondes";
    }
}
