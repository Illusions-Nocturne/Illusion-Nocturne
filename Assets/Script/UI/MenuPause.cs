using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject CanvasSheet;
    public GameObject InputSheet;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                Paused();
            }
        }
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        CanvasSheet.SetActive(false);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
        AudioManager.instance.PlaySong("ButtonMenu");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        CanvasSheet.SetActive(true);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
        AudioManager.instance.PlaySong("ButtonMenu");
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void ButtonInput()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        InputSheet.SetActive(true);
    }

}