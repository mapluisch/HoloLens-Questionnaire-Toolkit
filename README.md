<h1 align="center">HoloLens Questionnaire Toolkit</h1>

<div align="center">
  <img src="" alt="banner" style="width:50%">
  <p>Questionnaire Toolkit optimized for HoloLens using MRTK components.</p>
</div>

This repo is based on [VRQuestionnaireToolkit by MartinFk](https://github.com/MartinFk/VRQuestionnaireToolkit) and features the same toolkit, just optimized for Microsoft HoloLens. I've replaced the toolkit's `Prefabs` with MRTK-specific replacements.

Code-wise, it includes some minor QOL additions and, first and foremost, fixes and specific additions for UWP builds. I've tried to mostly leave the existing code from the original VRQuestionnaireToolkit *as is*.

## What's changed?
<table>
  <tr>
    <td><img src="https://github.com/mapluisch/HoloLens-Questionnaire-Toolkit/assets/31780571/b5192b73-0241-48da-a800-11e2d0dd6835" style="width: 100%;"></td>
    <td><img src="https://github.com/mapluisch/HoloLens-Questionnaire-Toolkit/assets/31780571/e42d803f-b881-4c6a-8b7c-a521c245d621" style="width: 100%;"></td>
    <td><img src="https://github.com/mapluisch/HoloLens-Questionnaire-Toolkit/assets/31780571/6514e274-4438-4332-bd21-e360e6e2d04d" style="width: 100%;"></td>
  </tr>
</table>


## Setup
1. Download this project and open the `SampleScene` in `Assets > Scenes > SampleScene`.
2. Run the sample scene via Holographic Remoting or build the project and install the `.appx`.

Alternatively, include the `Questionnaire Container` prefab from `Assets > Prefabs > Questionnaire Container` into your own scene.

For setting up the questionnaire itself, please refer to the [VRQuestionnaireToolkit-Wiki.](https://github.com/MartinFk/VRQuestionnaireToolkit/wiki)





