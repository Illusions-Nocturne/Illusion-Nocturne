using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider HealthBarSlider;

    public void UpdateHealthBar(float actualHealth, float maxHealth)
    {
       HealthBarSlider.value = actualHealth / maxHealth;
    }
}
