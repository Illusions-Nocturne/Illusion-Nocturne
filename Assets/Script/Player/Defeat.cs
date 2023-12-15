using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    public Character[] characters;

    void Update()
    {
        foreach (Character character in characters)
        {
            if (character.IsAlive())
                return;
        }

        SceneManager.LoadScene(SceneManager.loadedSceneCount-1);
        ChooseCharacter.CharacterChosen = 4;

    }
}