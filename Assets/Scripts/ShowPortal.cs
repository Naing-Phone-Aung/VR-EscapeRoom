using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowPortal : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable knife;
    public GameObject portal;

    private bool portalShown = false;

    void Start()
    {
        if (portal != null)
        {
            portal.SetActive(false); // Hide portal at start
        }

        knife.selectEntered.AddListener(OnKnifeGrabbed);
    }

    private void OnKnifeGrabbed(SelectEnterEventArgs args)
    {
        if (!portalShown && portal != null)
        {
            portal.SetActive(true); // Show portal instantly
            portalShown = true;
            Debug.Log("Knife grabbed — portal is now visible.");
        }
    }
}
