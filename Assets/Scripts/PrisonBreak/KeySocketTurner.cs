using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KeySocketTurner : MonoBehaviour
{
    public float turnAngle = 90f;
    public float turnDuration = 1f;
    public Transform attachTransform;
    public AudioClip keyTurningClip;
    public AudioClip doorOpenClip;
    public Animator doorAnimator;
    public string doorOpenTrigger = "OpenDoor";

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
    }

    void Update()
    {
        if (!hasTurned && socket != null && socket.hasSelection)
        {
            StartCoroutine(RotateKeyAndOpenDoor());
            hasTurned = true;
        }
    }

    private IEnumerator RotateKeyAndOpenDoor()
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

        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger(doorOpenTrigger);
        }

        if (doorOpenClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(doorOpenClip);
        }
    }
}
