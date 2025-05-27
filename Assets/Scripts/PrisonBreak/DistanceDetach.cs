using UnityEngine;

public class DistanceDetach : MonoBehaviour
{
    public float detachDistance = 0.15f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().enabled = false; 
    }

    void Update()
    {
        if (transform.parent == null) return;

        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > detachDistance)
        {
            transform.SetParent(null);
            rb.isKinematic = false;
        }
    }
}
