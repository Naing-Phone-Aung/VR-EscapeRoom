using UnityEngine;

public class CubeToggle : MonoBehaviour
{
    public Material whiteMat;
    public Material blackMat;
    public AudioClip toggleSound;             
    private AudioSource audioSource;

    private Renderer rend;
    private bool isWhite = false;

    public PuzzleManager puzzleManager; 

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = blackMat;

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
            puzzleManager.CheckWin();
    }

    public bool IsWhite() => isWhite;
}
