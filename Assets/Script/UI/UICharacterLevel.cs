using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterLevel : MonoBehaviour
{
    public Text LevelText;
    public Slider LevelSlider;
    public Character character;

    private void Update()
    {
        LevelText.text = "LVL " + character.Level;
        LevelSlider.value = character.CurrentExp / character.MaxExp;
    }
}
