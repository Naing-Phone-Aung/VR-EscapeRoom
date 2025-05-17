using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DropSound : MonoBehaviour
{
    public AudioClip hitSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(hitSound);
    }
}
