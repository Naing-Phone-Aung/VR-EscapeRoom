using UnityEngine;

public class CubeToggle : MonoBehaviour
{
    public Material whiteMat;
    public Material blackMat;
    public AudioClip toggleSound;             // Assign in Inspector
    private AudioSource audioSource;

    private Renderer rend;
    private bool isWhite = false;

    public PuzzleManager puzzleManager; // Assign this from the inspector or at runtime

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = blackMat;

        // Add or get AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    public void Toggle()
    {
        isWhite = !isWhite;
        rend.material = isWhite ? whiteMat : blackMat;

        if (toggleSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }

        if (puzzleManager != null)
            puzzleManager.CheckWin(); // Auto-check every toggle
    }

    public bool IsWhite() => isWhite;
}
