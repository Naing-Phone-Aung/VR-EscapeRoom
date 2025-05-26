using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public CubeToggle[] cubes;
    public bool[] solutionPattern;

    public AudioClip winSound;            
    public Animator doorAnimator;          
    public AudioSource audioSource;        

    private bool puzzleCompleted = false;

    public void CheckWin()
    {
        if (puzzleCompleted) return;

        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i].IsWhite() != solutionPattern[i])
                return; 
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
    }
}
