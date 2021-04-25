using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsManager : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resDropDown;
    public TMP_Dropdown qualityDropDown;
    private void Start()
    {
        qualityDropDown.value = QualitySettings.GetQualityLevel();
        resolutions = Screen.resolutions;

        resDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width)
            {
                currentResolutionIndex = i;
            }
        }
        resDropDown.AddOptions(options);
        resDropDown.value = currentResolutionIndex;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void ChangeMusicVolume(float volume)
    {
        FindObjectOfType<AudioManager>().ChangeVolume("Theme", volume);
    }
    public void FullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height,  Screen.fullScreen);
    }
}
