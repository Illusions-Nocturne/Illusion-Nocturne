using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public Slider slider;

    public void Update()
    {
        slider.value = MinValueAudio.values;
    }
}
