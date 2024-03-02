using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Martin Pluisch
 * Date: 1st of March, 2024
 * Description: Synchronizes the state of a UI toggle and MRTK's interactable counterpart.
 * License: MIT License
 */
public class ToggleSyncer : MonoBehaviour
{
    private Toggle uiToggle;
    private Interactable mrtkToggle;

    private void OnEnable()
    {
        uiToggle = GetComponent<Toggle>();
        mrtkToggle = GetComponent<Interactable>();
        
        uiToggle.onValueChanged.AddListener(SyncMRTKtoUI);
        mrtkToggle.OnClick.AddListener(SyncUItoMRTK);
    }

    private void OnDisable()
    {
        if (uiToggle) uiToggle.onValueChanged.RemoveListener(SyncMRTKtoUI);
        if (mrtkToggle) mrtkToggle.OnClick.RemoveListener(SyncUItoMRTK);
    }

    void SyncUItoMRTK() => uiToggle.isOn = mrtkToggle.IsToggled;
    void SyncMRTKtoUI(bool _) => mrtkToggle.IsToggled = uiToggle.isOn;
}
