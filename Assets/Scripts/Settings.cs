using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider volSlider;

    public Dropdown qualityDropdown;

    public Dropdown resolutionDropdown;

    public Toggle fullscreenToggle;

    private int screenInt;

    Resolution[] resolutions;

    private bool isFullscreen = false;

    const string prefName = "optionvalue";
    const string resName = "resolutionoption";

    void Awake()
    {
        screenInt = PlayerPrefs.GetInt("togglestate");
        
        if(screenInt == 1)
        {
            isFullscreen = true;
            fullscreenToggle.isOn = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }

        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resolutionDropdown.value);
            PlayerPrefs.Save();
        }));

        qualityDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, qualityDropdown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume");
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));

        qualityDropdown.value = PlayerPrefs.GetInt(prefName, 3);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        //audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
        audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if(isFullScreen == false)
        {
            PlayerPrefs.SetInt("togglestate", 0);
        }
        else
        {
            isFullScreen = true;
            PlayerPrefs.SetInt("togglestate", 1);
        }
    }
}
