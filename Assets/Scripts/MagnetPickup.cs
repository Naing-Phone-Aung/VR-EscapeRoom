using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MagnetPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Key")) return;

        XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (grab == null || rb == null) return;

        if (grab.isSelected) return; // already held? skip

        // ✅ Attach key to magnet
        grab.enabled = true; // make key grabbable now

        other.transform.SetParent(transform.parent); // parent = magnet
        other.transform.position = transform.position;
        other.transform.rotation = transform.rotation;

        rb.isKinematic = true; // disable physics so it stays stuck
    }
}
