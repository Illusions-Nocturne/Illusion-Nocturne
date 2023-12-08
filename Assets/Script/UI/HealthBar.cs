using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthBarSlider;
    public void UpdateHealthBar(float actualHealth)
    {
       HealthBarSlider.value = actualHealth;
    }
}
