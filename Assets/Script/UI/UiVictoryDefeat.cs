using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiVictoryDefeat : MonoBehaviour
{
    public static int life = 4;
    public static bool doudou;
    public GameObject UIVictoryDefeat;
    [SerializeField] private GameObject victoryDefeattext;

    void Update()
    {
        victoryDefeattext.GetComponent<Text>().text = (doudou) ? "Victoire" : "Defaite";
        if (doudou || life == 0)
        {
            UIVictoryDefeat.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
