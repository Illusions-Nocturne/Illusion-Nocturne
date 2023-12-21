using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiVictoryDefeat : MonoBehaviour
{
    public static int life = 4;
    public static bool doudou;
    public GameObject UIVictoryDefeat;
    public GameObject UIPlayer;
    public GameObject ComforterVictory;
    public GameObject ComforterDefeat;
    public GameObject Fond;
    [SerializeField] private GameObject victoryDefeattext;

    void Update()
    {
        victoryDefeattext.GetComponent<Text>().text = (doudou) ? "Victoire" : "Defaite";
        if (doudou || life == 0)
        {
            UIVictoryDefeat.SetActive(true);
            Fond.SetActive(true);
            UIPlayer.SetActive(false);
            Time.timeScale = 0.0f;
        }
        if (doudou)
        {
            ComforterVictory.SetActive(true);
            ComforterDefeat.SetActive(false);
        }
        else if (!doudou)
        {
            ComforterVictory.SetActive(false);
            ComforterDefeat.SetActive(true);
        }

    }
}
