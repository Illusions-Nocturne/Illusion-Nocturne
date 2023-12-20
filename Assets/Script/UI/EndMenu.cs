using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject Credit;
    public GameObject UIVictoryDefeat;
    public void ButtonRestart()
    {
        UiVictoryDefeat.doudou = false;
        Time.timeScale = 1.0f;
        UIVictoryDefeat.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
    public void ButtonCredit()
    {
        Credit.SetActive(true);
    }
    public void CloseButtonCredit()
    {
        Credit.SetActive(false);
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
