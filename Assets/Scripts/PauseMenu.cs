
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup pauseMenu;
    public ConfirmationMenu confirmationMenu;
    public ResolutionMenu resolutionMenu;
    public DisplaySettings displaySettings;

    public float fadeSpeed = 3f;

    private bool isPaused = false;
    private float targetAlpha = 0f;

    void Start()
    {
        InitialStateMenu();
    }

    void Update()
    {
        IsPaused();
        FadeMenu();
    }

    private void IsPaused()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused) { confirmationMenu.ShowConfirmation(); }
            else { OpenMenu(); }
        }
    }

    private void OpenMenu()
    {
        isPaused = true;
        targetAlpha = 1f;

        pauseMenu.interactable = true;
        pauseMenu.blocksRaycasts = true;

        Time.timeScale = 0f;
    }

    public void CloseMenu()
    {
        isPaused = false;
        targetAlpha = 0f;

        pauseMenu.interactable = false;
        pauseMenu.blocksRaycasts = false;

        Time.timeScale = 1f;
    }

    private void FadeMenu()
    {
        pauseMenu.alpha = Mathf.MoveTowards(pauseMenu.alpha,targetAlpha,fadeSpeed * Time.unscaledDeltaTime);
    }

    private void InitialStateMenu()
    {
        pauseMenu.alpha = 0f;
        pauseMenu.interactable = false;
        pauseMenu.blocksRaycasts = false;

        Time.timeScale = 1f;
    }
}
