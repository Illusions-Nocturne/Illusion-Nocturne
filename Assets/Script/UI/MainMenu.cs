using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsWindow;
    public GameObject InputPlayerWindow;

    public string SceneLoadName = "MainScene";

    public void OpenInputPlayer()
    {
        InputPlayerWindow.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneLoadName);
    }
    public void SettingsButton()
    {
        SettingsWindow.SetActive(true);
    }
    public void CloseSettingsButton()
    {
        SettingsWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
