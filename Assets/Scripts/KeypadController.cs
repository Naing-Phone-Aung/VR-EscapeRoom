using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeypadController : MonoBehaviour
{
    [Header("UI Components")]
    public TMP_Text inputText;
    public GameObject keypadCanvas;

    [Header("Door")]
    public GameObject door;
    public Transform pivotPoint;
    public Animator doorAnimator;

    [Header("Keypad Activation Trigger")]
    public GameObject keypadActivatorObject;

    [Header("Audio Feedback")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    [Header("Code Settings")]
    public string correctCode = "1234";

    private string currentInput = "";
    private bool unlocked = false;

    void Start()
    {
        if (door != null)
            doorAnimator = door.GetComponent<Animator>();
    }

    public void AddDigit(string digit)
    {
        if (unlocked) return;

        if (currentInput.Length < 10)
        {
            currentInput += digit;
            UpdateDisplay();
        }
    }

    public void Backspace()
    {
        if (unlocked) return;

        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplay();
        }
    }

    public void Submit()
    {
        if (unlocked) return;

        if (currentInput == correctCode)
        {
            unlocked = true;

            PlaySound(correctSound);

            if (doorAnimator != null)
                doorAnimator.SetTrigger("Open");

            if (keypadCanvas != null)
                keypadCanvas.SetActive(false);

            if (keypadActivatorObject != null)
                keypadActivatorObject.SetActive(false);
        }
        else
        {
            PlaySound(wrongSound);
        }

        currentInput = "";
        UpdateDisplay();
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void UpdateDisplay()
    {
        if (inputText != null)
            inputText.text = currentInput;
    }
}
