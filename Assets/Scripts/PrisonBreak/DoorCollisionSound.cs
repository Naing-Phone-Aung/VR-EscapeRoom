using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorCollisionSound : MonoBehaviour
{
    public AudioClip doorPushClip;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (doorPushClip != null && collision.gameObject.CompareTag("Controller"))
        {
            audioSource.PlayOneShot(doorPushClip);
        }
    }
}
