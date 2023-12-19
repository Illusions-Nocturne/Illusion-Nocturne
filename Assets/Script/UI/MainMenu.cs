using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsWindow;

    public void StartGame()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        SceneManager.LoadScene("MainScene");
    }
    public void SettingsButton()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        settingsWindow.SetActive(true);
    }
    public void CloseSettingsButton()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        settingsWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
