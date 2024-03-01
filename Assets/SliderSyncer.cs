using System;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// added by Martin Pluisch, 01. March 2024
/// maps the slider values of MRKT's slider to the UI Slider within the range of min and max val.
/// </summary>
public class SliderSyncer : MonoBehaviour
{
    private Slider uiSlider;
    private PinchSlider mrtkSlider;

    private void OnEnable()
    {
        uiSlider = GetComponent<Slider>();
        mrtkSlider = GetComponent<PinchSlider>();

        if (uiSlider && mrtkSlider) mrtkSlider.OnValueUpdated.AddListener(MapSliderValues);
    }
    
    private void OnDisable()
    {
        if (mrtkSlider) mrtkSlider.OnValueUpdated.RemoveListener(MapSliderValues);
    }

    void MapSliderValues(SliderEventData eventData) => uiSlider.value = uiSlider.minValue + eventData.NewValue * (uiSlider.maxValue - uiSlider.minValue);
}
