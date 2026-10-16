using UnityEngine;
public class ConfirmationMenu : MonoBehaviour
{
    public CanvasGroup confirmationPanel;
    public ResolutionMenu resolutionMenu;
    public DisplaySettings displaySettings;
    public PauseMenu pauseMenu;

    void Start()
    {
        HideConfirmation();
    }

    public void ShowConfirmation()
    {
        confirmationPanel.alpha = 1f;
        confirmationPanel.interactable = true;
        confirmationPanel.blocksRaycasts = true;
    }

    public void HideConfirmation()
    {
        confirmationPanel.alpha = 0f;
        confirmationPanel.interactable = false;
        confirmationPanel.blocksRaycasts = false;
    }

    public void CancelChanges()
    {
        resolutionMenu.CancelChanges();
        displaySettings.CancelChanges();

        HideConfirmation();
    }

    public void ConfirmExit()
    {
        HideConfirmation();

        resolutionMenu.CancelChanges();
        displaySettings.CancelChanges();

        pauseMenu.CloseMenu();
    }
}
