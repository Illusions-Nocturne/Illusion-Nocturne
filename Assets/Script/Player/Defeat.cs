using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    private Character character;

    private void Start()
    {
        character = GetComponent<Character>();
    }
    void Update()
    {
        if (character.Hp <=0)
        {
            SceneManager.LoadScene(SceneManager.loadedSceneCount-1);
        }
    }
}