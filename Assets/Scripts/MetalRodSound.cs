using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MetalRodSound : MonoBehaviour
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
        // Optional: check if it hit the ground by tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(hitSound);
        }
    }
}
