using UnityEngine;

public class KeypadActivator : MonoBehaviour
{
    public GameObject keypadUI;
    private bool isVisible = false;

    public void ToggleKeypad()
    {
        isVisible = !isVisible;
        if (keypadUI != null)
            keypadUI.SetActive(isVisible);
    }
}
