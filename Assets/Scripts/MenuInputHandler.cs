using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInputHandler : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference actionReference;
    public UnityEvent actionEvent;

    [Header("Menu Panels")]
    public GameObject pauseMenuPanel;
    public GameObject cheatSheetPanel;
    public GameObject quitConfirmationPanel;

    private bool isPaused = false;

    void Start()
    {
        if (actionReference != null)
            actionReference.action.performed += OnButtonPressed;
    }

    private void OnDestroy()
    {
        if (actionReference != null)
            actionReference.action.performed -= OnButtonPressed;
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        actionEvent.Invoke();

        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        ShowOnlyPanel(pauseMenuPanel);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        HideAllPanels();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowCheatSheet()
    {
        ShowOnlyPanel(cheatSheetPanel);
    }

    public void PromptQuitGame()
    {
        ShowOnlyPanel(quitConfirmationPanel);
    }

    public void ConfirmQuit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void CancelQuit()
    {
        ShowOnlyPanel(pauseMenuPanel);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene");
    }

    public void BackToPauseMenu()
    {
        ShowOnlyPanel(pauseMenuPanel);
    }

    private void ShowOnlyPanel(GameObject panelToShow)
    {
        // Disable all first
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        if (cheatSheetPanel != null) cheatSheetPanel.SetActive(false);
        if (quitConfirmationPanel != null) quitConfirmationPanel.SetActive(false);

        // Enable target
        if (panelToShow != null) panelToShow.SetActive(true);
    }

    private void HideAllPanels()
    {
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        if (cheatSheetPanel != null) cheatSheetPanel.SetActive(false);
        if (quitConfirmationPanel != null) quitConfirmationPanel.SetActive(false);
    }
}
