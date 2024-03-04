using System;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Martin Pluisch
 * Date: 1st of March, 2024
 * Description: Maps & refreshes the slider values of MRKT's slider to the UI Slider within the range of min and max val.
 * License: MIT License
 */
public class SliderSyncer : MonoBehaviour
{
    private Slider uiSlider;
    private PinchSlider mrtkSlider;

    private void OnEnable()
    {
        uiSlider = GetComponent<Slider>();
        mrtkSlider = GetComponent<PinchSlider>();
        
        if (uiSlider && mrtkSlider) mrtkSlider.OnInteractionEnded.AddListener(MapSliderValues);
    }
    
    private void OnDisable()
    {
        if (mrtkSlider) mrtkSlider.OnInteractionEnded.RemoveListener(MapSliderValues);
    }

    void MapSliderValues(SliderEventData eventData)
    {
        // first, map uiSlider val to relative mrtk slider val (clamped between 0-1, you sadly can't set fixed min-max-vals)
        uiSlider.value = Mathf.Lerp(uiSlider.minValue, uiSlider.maxValue, mrtkSlider.SliderValue);
        // then, normalize uiSlider.value and map it to the mrtk SliderValue for snapping into position
        mrtkSlider.SliderValue = (uiSlider.value - uiSlider.minValue) / (uiSlider.maxValue - uiSlider.minValue);
    } 
}
