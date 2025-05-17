using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KeySocketTurner : MonoBehaviour
{
    public float turnAngle = 90f;
    public float turnDuration = 1f;
    public Transform attachTransform;
    public Rigidbody doorRigidbody;

    private XRSocketInteractor socket;
    private bool hasTurned = false;
    private Quaternion initialAttachRotation;

    void Awake()
    {
        socket = GetComponentInChildren<XRSocketInteractor>();

        if (attachTransform != null)
            initialAttachRotation = attachTransform.localRotation;

        if (doorRigidbody != null)
        {
            doorRigidbody.isKinematic = true;
            doorRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    void Update()
    {
        if (!hasTurned && socket != null && socket.hasSelection)
        {
            StartCoroutine(RotateKeyAndUnlockDoor());
            hasTurned = true;
        }
    }

    private IEnumerator RotateKeyAndUnlockDoor()
    {
        if (attachTransform == null)
            yield break;

        Quaternion startRot = attachTransform.localRotation;
        Quaternion endRot = startRot * Quaternion.Euler(0f, 0f, turnAngle);

        float elapsed = 0f;
        while (elapsed < turnDuration)
        {
            attachTransform.localRotation = Quaternion.Slerp(startRot, endRot, elapsed / turnDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        attachTransform.localRotation = endRot;

        yield return new WaitForFixedUpdate();

        if (doorRigidbody != null)
        {
            doorRigidbody.isKinematic = false;
            doorRigidbody.WakeUp();
        }
    }
}
