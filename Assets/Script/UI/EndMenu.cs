using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject Credit;
    public void ButtonRestart()
    {
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
