using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiVictoryDefeat : MonoBehaviour
{
    public int life;
    public bool doudou;
    public GameObject UIVictoryDefeat;
    [SerializeField] private GameObject victoryDefeattext;

    void Update()
    {
        victoryDefeattext.GetComponent<Text>().text = (doudou) ? "Victoire" : "Defaite";
        if (doudou || life == 0)
        {
            UIVictoryDefeat.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            doudou = false;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            doudou = true;
        }
    }
}
