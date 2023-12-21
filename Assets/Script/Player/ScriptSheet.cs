using UnityEngine;

public class ScriptSheet : MonoBehaviour
{
    public GameObject PersonalSheet1;
    public GameObject PersonalSheet2;
    public GameObject PersonalSheet3;
    public GameObject PersonalSheet4;
    public void SheetButton()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        PersonalSheet1.SetActive(true);
        PersonalSheet2.SetActive(false);
        PersonalSheet3.SetActive(false);
        PersonalSheet4.SetActive(false);
    }

    public void CloseSheet()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        PersonalSheet1.SetActive(false);
    }

}
