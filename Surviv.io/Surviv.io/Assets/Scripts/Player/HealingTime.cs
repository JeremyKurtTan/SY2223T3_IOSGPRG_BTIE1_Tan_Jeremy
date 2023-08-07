using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingTime : MonoBehaviour
{
    public Slider slider;

    public float FillSpeed = 0.35f;
    public float targetProgress = 0;

    private void Update()
    {
        if(slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
    }

    public void IncrementBar(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void ResetBar()
    {
        slider.value = 0;
    }
}
