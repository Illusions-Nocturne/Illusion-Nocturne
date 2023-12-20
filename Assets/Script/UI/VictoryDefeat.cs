using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDefeat : MonoBehaviour
{
    public Character[] Character;

    public void Update()
    {
        for (int i = 0; i < Character.Length; i++)
        {
            if (Character[i].IsAlive())
            {
                return;
            }
        }
        UiVictoryDefeat.life = 0;
    }
}
