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
