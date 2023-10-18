using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Dropdown resolutionsDropDown;
    [SerializeField] private Canvas menuUI;

    Resolution[] resolutions;

    private void Start()
    {
        string option;
        List<string> options = new List<string>();
        closeMenu();

        resolutions = Screen.resolutions;
        resolutionsDropDown.ClearOptions();       

        for(int i=0; i<resolutions.Length; i++)
        {
            option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }

        resolutionsDropDown.AddOptions(options);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void closeMenu()
    {
        menuUI.enabled = false;
    }

    public void openMenu()
    {
        menuUI.enabled = true;
    }
}
