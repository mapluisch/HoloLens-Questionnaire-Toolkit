using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine.UI;
using VRQuestionnaireToolkit;

/*
 * Author: Martin Pluisch
 * Date: 2nd of March, 2024
 * Description: Class responsible for switching Questionnaire's design between the standard 'VR' theme, and a MRTK-based HoloLens one.
 * License: MIT License
 */
[Serializable]
public struct ColorTheme
{
    public Color header;
    public Color main;
    public Color footer;
    public Color text;
}
public class ThemeSwitcher : MonoBehaviour
{
    [SerializeField] private bool useHoloLensDesign = true;
    [SerializeField] private ColorTheme baseTheme, mrtkTheme;
    [SerializeField] private Material buttonMaterial;
    private List<GameObject> panels = new List<GameObject>();
    // used for color lerping in PageController when mandatory questions have not been answered (replaces hard-coded Color.black in the original script)
    public static Color TextColor; 

    private void OnEnable() => GenerateQuestionnaire.OnQuestionnaireGenerated += RefreshTheme;
    private void OnDisable() => GenerateQuestionnaire.OnQuestionnaireGenerated -= RefreshTheme;

    public void RefreshTheme()
    {
        // cache all relevant panels
        panels.AddRange(GameObject.FindObjectsOfType<GameObject>(true).Where(o => o.name == "Q_Panel"));
        
        ColorTheme theme = (useHoloLensDesign) ? mrtkTheme : baseTheme;
        
        foreach (var panel in panels)
        {
            var header = panel.transform.GetChild(0);
            var main = panel.transform.GetChild(1);
            var footer = panel.transform.GetChild(2);

            // update page components' color
            header.GetComponent<Image>().color = theme.header;
            main.GetComponent<Image>().color = theme.main;
            footer.GetComponent<Image>().color = theme.footer;
            
            // update all text elements' color
            panel.GetComponentsInChildren<TextMeshProUGUI>(true).ToList().ForEach(t => t.color = theme.text);
            panel.GetComponentsInChildren<TextMeshPro>(true).ToList().ForEach(t => t.color = theme.text);
            
            // set global text color var
            TextColor = theme.text;

            buttonMaterial.color = theme.main;
        }
    }
}
