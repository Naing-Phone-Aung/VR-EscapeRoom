using UnityEngine;

public class BallHitHandler : MonoBehaviour
{
    public GameObject[] cubesToDrop; // Assign destructible cubes in Inspector
    public float dropForce = 1.5f;
    public AudioClip revealClip;     // Assign your audio clip in the Inspector
    private bool triggered = false;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Ball")) return;

        triggered = true;

        foreach (GameObject cube in cubesToDrop)
        {
            if (cube != null)
            {
                Rigidbody rb = cube.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = cube.AddComponent<Rigidbody>();
                }

                rb.useGravity = true;
                rb.isKinematic = false;
                rb.AddForce(Vector3.back * dropForce, ForceMode.Impulse);
            }
        }

        if (revealClip != null)
        {
            audioSource.PlayOneShot(revealClip);
        }

        Debug.Log("🎯 Pattern revealed!");
    }
}
