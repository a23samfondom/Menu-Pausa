
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ResolutionMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> availableResolutions = new List<Resolution>();

    private int selectedResolution;

    void Start()
    {
        LoadResolutions();
        LoadResolution();
    }

    public void LoadResolutions()
    {
        resolutions = Screen.resolutions;

        availableResolutions.Clear();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + "x" + resolution.height;

            if (!options.Contains(option))
            {
                options.Add(option);
                availableResolutions.Add(resolution);
            }
        }

        resolutionDropdown.AddOptions(options);
    }

    public void ChangeResolution()
    {
        selectedResolution = resolutionDropdown.value;
    }

    public void ApplySettings()
    {
        if (availableResolutions.Count > 0)
        {
            Resolution resolution = availableResolutions[selectedResolution];

            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

            PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
            PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
            PlayerPrefs.Save();
        }
    }

    public void LoadResolution()
    {
        int width = PlayerPrefs.GetInt("ResolutionWidth", Screen.width);
        int height = PlayerPrefs.GetInt("ResolutionHeight", Screen.height);

        selectedResolution = 0;

        for (int i = 0; i < availableResolutions.Count; i++)
        {
            if (availableResolutions[i].width == width && availableResolutions[i].height == height)
            {
                selectedResolution = i;
            }
        }

        resolutionDropdown.value = selectedResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void CancelChanges()
    {
        for (int i = 0; i < availableResolutions.Count; i++)
        {
            if (availableResolutions[i].width == Screen.width && availableResolutions[i].height == Screen.height)
            {
                selectedResolution = i;
            }
        }

        resolutionDropdown.value = selectedResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void DefaultValues()
    {
        selectedResolution = 0;

        resolutionDropdown.value = selectedResolution;
        resolutionDropdown.RefreshShownValue();
    }

}
