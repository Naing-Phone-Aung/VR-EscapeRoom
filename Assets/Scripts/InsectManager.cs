using UnityEngine;

public class InsectManager : MonoBehaviour
{
    public static InsectManager Instance;

    public InsectCube[] cubesInOrder; 
    public int[] correctSequence = new int[3];

    public AudioClip successSound;        
    public Animator doorAnimator;         
    public AudioSource audioSource;      

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
        Debug.Log("Correct sequence!");

        if (successSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(successSound);
        }

        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }

     
    }
}
