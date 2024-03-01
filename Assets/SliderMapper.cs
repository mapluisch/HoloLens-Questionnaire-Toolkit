using System;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// added by Martin Pluisch, 01. March 2024
/// maps the slider values of MRKT's slider to the UI Slider within the range of min and max val.
/// </summary>
public class SliderMapper : MonoBehaviour
{
    private Slider uiSlider;
    private PinchSlider mrtkSlider;

    private void OnEnable()
    {
        if (!uiSlider) uiSlider = GetComponent<Slider>();
        if (!mrtkSlider) mrtkSlider = GetComponent<PinchSlider>();

        if (mrtkSlider) mrtkSlider.OnValueUpdated.AddListener(MapSliderValues);
    }

    void MapSliderValues(SliderEventData eventData)
    {
        if (uiSlider) uiSlider.value = uiSlider.minValue + eventData.NewValue * (uiSlider.maxValue - uiSlider.minValue);
    }
}
