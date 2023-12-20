using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void UpdateHealthBar(float CurrentValue, float MaxValue)
    {
        slider.value = CurrentValue / MaxValue;
    }
}
