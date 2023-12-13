using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthBarSlider1;
    public Slider HealthBarSlider2;
    public Slider HealthBarSlider3;
    public Slider HealthBarSlider4;
    public void UpdateHealthBar(float actualHealth)
    {
        if (ChooseCharacter.CharacterChosen == 0)
        {
            HealthBarSlider1.value = actualHealth;
        }
        else if (ChooseCharacter.CharacterChosen == 1) 
        { 
            HealthBarSlider2.value = actualHealth;
        }
        else if (ChooseCharacter.CharacterChosen == 3)
        {
            HealthBarSlider4.value = actualHealth;
        }
        else if (ChooseCharacter.CharacterChosen == 2)
        {
            HealthBarSlider3.value = actualHealth;
        }
        else if (ChooseCharacter.CharacterChosen == 4)
        {
            HealthBarSlider1.value = actualHealth;
            HealthBarSlider2.value = actualHealth;
            HealthBarSlider3.value = actualHealth;
            HealthBarSlider4.value = actualHealth;
        }
    }
}
