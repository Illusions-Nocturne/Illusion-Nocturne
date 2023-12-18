using UnityEngine;
using UnityEngine.UI;

public class GetHp : MonoBehaviour
{
    public Character stats;
    void Update()
    {
        if (stats.CurrentHp < 0)
            stats.CurrentHp = 0;

        GetComponent<Text>().text = stats.CurrentHp.ToString() + "/" + stats.MaxHp.ToString();
    }
}