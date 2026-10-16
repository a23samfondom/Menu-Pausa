
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{
    public Toggle fullscreenToggle;

    private bool pendingFullscreen;

    void Start()
    {
        bool fullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        pendingFullscreen = fullscreen;
        fullscreenToggle.SetIsOnWithoutNotify(fullscreen);

        Screen.fullScreen = fullscreen;
    }

    public void ChangeFullscreen()
    {
        pendingFullscreen = fullscreenToggle.isOn;
    }

    public void ApplySettings()
    {
        pendingFullscreen = fullscreenToggle.isOn;

        Screen.fullScreen = pendingFullscreen;

        PlayerPrefs.SetInt("Fullscreen", pendingFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void CancelChanges()
    {
        pendingFullscreen = Screen.fullScreen;
        fullscreenToggle.SetIsOnWithoutNotify(pendingFullscreen);
    }

    public void DefaultValues()
    {
        pendingFullscreen = true;
        fullscreenToggle.SetIsOnWithoutNotify(true);
    }

}
