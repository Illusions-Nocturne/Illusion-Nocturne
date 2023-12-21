using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIInputCharacter : MonoBehaviour
{
    public GameObject Canvas;

    public void ClosePanel()
    {
        AudioManager.instance.PlaySong("ButtonMenu");
        Canvas.SetActive(false);
    }
}
