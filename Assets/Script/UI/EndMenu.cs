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
        AudioManager.instance.PlaySong("ButtonMenu");
        SceneManager.LoadScene("MainScene");
    }
    public void ButtonCredit()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        Credit.SetActive(true);
    }
    public void CloseButtonCredit()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        Credit.SetActive(false);
    }
    public void ButtonMenu()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
    }
}
