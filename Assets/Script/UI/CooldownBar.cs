using System;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    public Slider CooldownBarSlider1;
    public Slider CooldownBarSlider2;
    public Slider CooldownBarSlider3;
    public Slider CooldownBarSlider4;

    public Character SwordMan;
    public Character Protector;
    public Character Mage;
    public Character Cleric;

    private void Start()
    {
        CooldownSlider();
    }
    private void Update()
    {
            if (CooldownBarSlider1.value != CooldownBarSlider1.maxValue)
            {
                CooldownBarSlider1.value += Time.deltaTime;
            }
            if (CooldownBarSlider2.value != CooldownBarSlider2.maxValue)
            {
                CooldownBarSlider2.value += Time.deltaTime;
            }
            if (CooldownBarSlider3.value != CooldownBarSlider3.maxValue)
            {
                CooldownBarSlider3.value += Time.deltaTime;
            }
            if (CooldownBarSlider4.value != CooldownBarSlider4.maxValue)
            {
                CooldownBarSlider4.value += Time.deltaTime;
            }
    }

    public void UpdateCooldownBar()
    {
        switch (ChooseCharacter.CharacterChosen)
        {
            case 0: CooldownBarSlider1.value = 0; break;
            case 1: CooldownBarSlider2.value = 0; break;
            case 2: CooldownBarSlider3.value = 0; break;
            case 3: CooldownBarSlider4.value = 0; break;
        }
    }

    public void CooldownSlider()
    {
        CooldownBarSlider1.maxValue = SwordMan.CDBaseAttack;
        CooldownBarSlider2.maxValue = Protector.CDBaseAttack;
        CooldownBarSlider3.maxValue = Mage.CDBaseAttack;
        CooldownBarSlider4.maxValue = Cleric.CDBaseAttack;
        CooldownBarSlider1.value = CooldownBarSlider1.maxValue;
        CooldownBarSlider2.value = CooldownBarSlider2.maxValue;
        CooldownBarSlider3.value = CooldownBarSlider3.maxValue;
        CooldownBarSlider4.value = CooldownBarSlider4.maxValue;
    }
}
