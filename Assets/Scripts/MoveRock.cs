using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MoveRockOnKnifeGrab : MonoBehaviour
{
    public XRGrabInteractable knife;
    public Animator rockAnimator;
    public string animationTrigger = "RockDown";
    public AudioSource rockAudio; 

    private bool hasMoved = false;

    void Start()
    {
        knife.selectEntered.AddListener(OnKnifeGrabbed);
    }

    private void OnKnifeGrabbed(SelectEnterEventArgs args)
    {
        if (!hasMoved && rockAnimator != null)
        {
            rockAnimator.SetTrigger(animationTrigger);

            // Play sound
            if (rockAudio != null)
            {
                rockAudio.Play();
            }

            hasMoved = true;
            Debug.Log("Knife grabbed rock is moving down.");
        }
    }
}
