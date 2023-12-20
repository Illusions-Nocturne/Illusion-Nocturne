using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDefeat : MonoBehaviour
{
    public Character[] Character;
    public GameObject UIVictoryDefeat;

    public void Update()
    {
        for (int i = 0; i < Character.Length; i++)
        {
            if (Character[i].IsAlive())
            {
                return;
            }
        }
        Time.timeScale = 0.0f;
        UIVictoryDefeat.SetActive(false);
        UiVictoryDefeat.life = 0;
    }
}
