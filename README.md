<h1 align="center">HoloLens Questionnaire Toolkit</h1>

<div align="center">
  <img src="" alt="banner" style="width:50%">
  <p>Questionnaire Toolkit optimized for HoloLens using standard MRTK components. Easily administer questionnaires in HoloLens-related studies.</p>
</div>
<hr>

This repo is based on [VRQuestionnaireToolkit by MartinFk](https://github.com/MartinFk/VRQuestionnaireToolkit) and features the same toolkit, just optimized for Microsoft HoloLens. I've replaced the toolkit's components with MRTK-specific replacements and optimized the setup for HoloLens.

Code-wise, it includes some minor QOL additions and, first and foremost, fixes and specific additions for UWP builds. I've tried to mostly leave the existing code from the original VRQuestionnaireToolkit *as is*, so that existing support- and Wiki-docs remain valid.

## What's changed?
<table>
  <tr>
    <td><img src="https://github.com/mapluisch/HoloLens-Questionnaire-Toolkit/assets/31780571/b5192b73-0241-48da-a800-11e2d0dd6835" style="width: 100%;"></td>
    <td><img src="https://github.com/mapluisch/HoloLens-Questionnaire-Toolkit/assets/31780571/e42d803f-b881-4c6a-8b7c-a521c245d621" style="width: 100%;"></td>
    <td><img src="https://github.com/mapluisch/HoloLens-Questionnaire-Toolkit/assets/31780571/6514e274-4438-4332-bd21-e360e6e2d04d" style="width: 100%;"></td>
  </tr>
  <tr>
    <td align="center"><em>Movable, resizable, and rotatable view</em></td>
    <td align="center"><em>Near and far MRTK interactions</em></td>
    <td align="center"><em>Swapped native interaction components</em></td>
  </tr>
</table>

### Interactable Components
- Replaced all `UnityEngine.UI` components with their MRTK counterparts. If there's no one-to-one replacement (e.g. `LinearGrid`), I've combined multiple components into one.
- Wrapped the questionnaire container into a standard MRTK slate with 6-DOF, variable user-defined scaling at runtime, and "Follow Me" functionality.
- Added helper scripts to sync values between MRTK components and the underlying UI components, so that the [VRQuestionnaireToolkit](https://github.com/MartinFk/VRQuestionnaireToolkit) source code stays untouched (for the most part); e.g.:
  - MRTK's slider is only defined for a fixed value range of 0..1. My `SliderSyncer.cs` script takes the MRTK slider's value and syncs it to a base `UnityEngine.UI.Slider` (i.e. maps the value range and updates both accordingly).
- All components are both near ("touch") and far (ray + "air tap") interactable.

### Design
- Added a small `ThemeSwitcher` component which simply toggles between the original [VRQuestionnaireToolkit by MartinFk](https://github.com/MartinFk/VRQuestionnaireToolkit) color scheme and a more HoloLens-native one.
- If you don't want to use either of them, feel free to specify your own color theme within the `ThemeSwitcher` component (split into header, main, footer, and text color attributes).

<div align="center">
  <table>
    <tr>
      <td><img src="https://github.com/mapluisch/HoloLens-Questionnaire-Toolkit/assets/31780571/90d6dae3-6a25-49e5-9272-1d7199afa8bf" alt="Base theme" style="width:250px;"></td>
      <td><img src="https://github.com/mapluisch/HoloLens-Questionnaire-Toolkit/assets/31780571/64d6ca36-1b32-4b9e-b567-1e9a08afd988" alt="MRTK theme" style="width:250px;"></td>
    </tr>
    <tr>
      <td align="center"><em>Base theme</em></td>
      <td align="center"><em>MRTK theme</em></td>
    </tr>
  </table>
</div>

### QOL
- Added new subscribable events:
  -  `GenerateQuestionnaire.OnQuestionnaireGenerated` - invoked when the JSON files have been parsed and the questionnaire container has been filled.
  -  `ExportToCSV.OnQuestionnaireDataSaved` - invoked once the .CSV answers have been stored locally.
  -  `ExportToCSV.OnQuestionnaireDataSentToServer` - invoked once the answers have been successfully sent to the server.
- Customizable themes.
- Movable, resizable questionnaire container for easier user-directed interactions.
- Removed hardcoded positioning of questionnaire container.

### Misc
- Had to remove tactile feedback and the `FeedbackManager` for obvious reasons.
- Audio feedback is still present and gets automatically generated within the MRTK components.

## Setup
### Dependencies
All MRTK dependencies refer to **v2.8.3**. I have not tested alternative MRTK versions (yet).
- MRTK Foundation
- MRTK Standard Assets 
- MRTK Examples

If you want to use this repo as is, as standalone, or as a base for a fresh Unity project:

0. Clone this repo.
1. Include the dependencies mentioned above via Microsoft's `MixedRealityFeatureTool` and make sure to use OpenXR when asked by MRTK.
2. Open the project within Unity and load the `SampleScene` in `Assets > Scenes > SampleScene`.
3. Run the sample scene via Holographic Remoting or build the project and install the `.appx`.

Alternatively, if you want to use this in your existing project:

0. Download the latest release `.unitypackage` and make sure that your project meets the dependency requirements.
1. Import the package via `Assets > Import Package`.
2. Include the `Questionnaire Container` prefab from `Assets > Prefabs > Questionnaire Container` into your own MRTK-enabled scene.

Within the `Questionnaire Container`, you will find the `ThemeSwitcher` class, but more importantly, the `HoloLensQuestionnaireToolkit` (= `VRQuestionnaireToolkit`) in which you can specify your questionnaire data.

For setting up the questionnaire itself, please refer to the [VRQuestionnaireToolkit-Wiki.](https://github.com/MartinFk/VRQuestionnaireToolkit/wiki)

## Build & Run
Where to store your questionnaires' .JSON files:

- HoloLens build:
  - If you want to administer your questionnaires in a UWP build **running on HoloLens**, include your .JSON files within the `Resources` folder. Specify *the same subdirectory* minus "Assets/Resources/" as path in the `GenerateQuestionnaire` component.
  - Example:
      -  Your questionnaire `questionnaire.json` is stored in `Assets/Resources/questionnaire.json` &rArr; specify `questionnaire.json` as input path within `GenerateQuestionnaire`.
      -  Your questionnaire `questionnaire.json` is stored in `Assets/Resources/some/subdirectories/questionnaire.json` &rArr; specify `some/subdirectories/questionnaire.json` as input path within `GenerateQuestionnaire`.
- Holographic Remoting:
   - If you conduct your study via remoting, simply include your .JSON files somewhere within your Assets folder and specify **the path as is** in the `GenerateQuestionnaire` component.
   - Example:
      -  Your questionnaire `questionnaire.json` is stored in `Assets/questionnaire.json` &rArr; specify `Assets/questionnaire.json` as input path within `GenerateQuestionnaire`.
      -  Your questionnaire `questionnaire.json` is stored in `Assets/again/some/subdirectories/questionnaire.json` &rArr; specify `Assets/again/some/subdirectories/questionnaire.json` as input path within `GenerateQuestionnaire`.

## Output
Once again there's a discrepancy between running the questionnaire on-device opposed to via remoting. 

- HoloLens build:
  - Once the questionnaire has been submitted, the `.csv` can be found in `LocalAppData/<your app ID>/LocalState/`. Access via the file manager within the device portal, for example. The subdirectory cannot be changed.
- Holographic Remoting:
  - Since the toolkit runs on your PC in this case, the `.csv` can be found in `Assets/Questionnaires/Data/Answers` within Unity. You can edit this path to your liking within the `ExportToCSV` component.

## Disclaimer
This project is mostly an extension to the original [VRQuestionnaireToolkit by MartinFk](https://github.com/MartinFk/VRQuestionnaireToolkit), so special thanks to them for their work and efforts!

I made sure that all base functions work as expected (tested with Unity v2022.3.19f1), but you still have to extensively test this toolkit *with your own setup* **before** conducting a study. Test your integration, the workflow, whether your input .JSONs are correctly read, and the output .CSVs are accessible and readable. Neither I nor the original authors of the VRQuestionnaireToolkit are responsible if you lose questionnaire responses, so please ensure everything is working as expected on your end. 😊
