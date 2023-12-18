using UnityEngine;
using UnityEngine.UI;

public class GetCD : MonoBehaviour
{
    public Character stats;
    void Update()
    {
        if (stats.CurrentCD < 0)
            stats.CurrentCD = 0;

        GetComponent<Text>().text = stats.CurrentCD.ToString("0.0");
    }
}