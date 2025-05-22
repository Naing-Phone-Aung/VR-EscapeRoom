using UnityEngine;


public class UnlockKnife : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket1;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket2;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket3;
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable knife;

    void Start()
    {
        knife.enabled = false;
    }

    void Update()
    {
        if (!knife.enabled && socket1.hasSelection && socket2.hasSelection && socket3.hasSelection)
        {
            knife.enabled = true;
            Debug.Log("Knife is now unlocked.");
        }
    }
}
