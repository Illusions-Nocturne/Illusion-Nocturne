using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSheetLevel : MonoBehaviour
{
    Text LevelText;
    Character character;

    private void Update()
    {
        LevelText.text = character.Level.ToString();
    }
}
