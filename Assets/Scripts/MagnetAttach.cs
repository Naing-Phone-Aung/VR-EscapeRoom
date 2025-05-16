using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MagnetAttach : MonoBehaviour
{
    public string attachPointName = "AttachPoint";
    private bool isAttached = false;
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAttached) return;

        if (other.gameObject.name == attachPointName)
        {
            // Detach from hand
            if (grabInteractable.isSelected)
            {
                grabInteractable.interactionManager.SelectExit(grabInteractable.firstInteractorSelecting, grabInteractable);
            }

            // Snap and attach
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            transform.SetParent(other.transform);

            // Disable physics
            rb.isKinematic = true;
            grabInteractable.enabled = false;

            isAttached = true;
        }
    }
}
