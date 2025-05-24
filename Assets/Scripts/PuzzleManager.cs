using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public CubeToggle[] cubes;
    public bool[] solutionPattern;

    public AudioClip winSound;             // Assign in Inspector
    public Animator doorAnimator;          // Assign Animator with "Open" trigger
    public AudioSource audioSource;        // Optional: assign or let it auto-create

    private bool puzzleCompleted = false;

    public void CheckWin()
    {
        if (puzzleCompleted) return;

        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i].IsWhite() != solutionPattern[i])
                return; // Not correct yet
        }

        puzzleCompleted = true;
        Debug.Log("🎉 Puzzle Solved!");

        // Play sound
        if (winSound != null)
        {
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            audioSource.PlayOneShot(winSound);
        }

        // Trigger door open animation
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }

        // Add any additional win logic here (particles, level transition, etc.)
    }
}
