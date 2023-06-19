using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DashMeterBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxDashMeter( int dashMeter)
    {
        slider.maxValue = dashMeter;
        slider.value = dashMeter;
    }
    public void SetDashMeter(int dashMeter)
    {
        slider.value = dashMeter;
    }
}
