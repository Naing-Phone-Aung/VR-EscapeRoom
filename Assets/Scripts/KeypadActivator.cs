using UnityEngine;

public class KeypadActivator : MonoBehaviour
{
    public GameObject keypadUI;
    private bool isVisible = false;
    private bool isLocked = false;

    public void ToggleKeypad()
    {
        if (isLocked) return;

        isVisible = !isVisible;
        if (keypadUI != null)
            keypadUI.SetActive(isVisible);
    }

    public void LockActivator()
    {
        isLocked = true;
        // Optionally, hide the UI if it's currently open
        if (keypadUI != null)
            keypadUI.SetActive(false);
    }
}
