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
                UiVictoryDefeat.life = 4;
                if (!MenuPause.gameIsPaused)
                {
                    Time.timeScale = 1.0f;
                }
                return;
            }
        }
        Time.timeScale = 0.0f;
        UiVictoryDefeat.life = 0;
    }
}
