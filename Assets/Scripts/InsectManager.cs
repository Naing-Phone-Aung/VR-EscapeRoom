using UnityEngine;

public class InsectManager : MonoBehaviour
{
    public static InsectManager Instance;

    public InsectCube[] cubesInOrder; // Assign the 3 cubes in order (left to right)
    public int[] correctSequence = new int[3];

    public AudioClip successSound;        // Assign in Inspector
    public Animator doorAnimator;         // Assign door Animator with "Open" trigger
    public AudioSource audioSource;       // Optional: will auto-create if not set

    private bool sequenceCompleted = false;

    private void Awake()
    {
        Instance = this;

        // Auto-assign AudioSource if missing
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
    }

    public void CheckSequence()
    {
        if (sequenceCompleted) return;

        if (cubesInOrder.Length != correctSequence.Length)
        {
            Debug.LogWarning("Mismatch between number of cubes and answer sequence!");
            return;
        }

        for (int i = 0; i < cubesInOrder.Length; i++)
        {
            if (cubesInOrder[i].currentIndex != correctSequence[i])
                return;
        }

        sequenceCompleted = true;
        Debug.Log("✅ Correct sequence!");

        // 🔊 Play success sound
        if (successSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(successSound);
        }

        // 🚪 Trigger door animation
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }

        // Add more success logic here if needed
    }
}
