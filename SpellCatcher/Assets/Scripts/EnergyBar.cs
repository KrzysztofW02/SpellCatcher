using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    public void UpdateEnergyBar(float CurrentValue, float MaxValue)
    {
        slider.value = CurrentValue / MaxValue;
    }
}
