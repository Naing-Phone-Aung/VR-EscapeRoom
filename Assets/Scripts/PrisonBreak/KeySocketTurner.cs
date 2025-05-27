using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KeySocketTurner : MonoBehaviour
{
    public float turnAngle = 90f;
    public float turnDuration = 1f;
    public Transform attachTransform;
    public Rigidbody doorRigidbody;

    public AudioClip keyTurningClip;

    private XRSocketInteractor socket;
    private bool hasTurned = false;
    private Quaternion initialAttachRotation;
    private AudioSource audioSource;

    void Awake()
    {
        socket = GetComponentInChildren<XRSocketInteractor>();
        audioSource = GetComponent<AudioSource>();

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

        if (keyTurningClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(keyTurningClip);
        }

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
