using UnityEngine;

public class UITriggerZone : MonoBehaviour
{
    public GameObject uiToShow; // Assign your UI prefab or object here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiToShow != null)
                uiToShow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiToShow != null)
                uiToShow.SetActive(false);
        }
    }
}

