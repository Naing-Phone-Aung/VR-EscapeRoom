using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class FlashHintBlink : MonoBehaviour
{
    [Header("Flash Settings")]
    public Color flashColor = Color.white;
    public float flashDuration = 0.6f;     // Time it takes to fully flash in/out
    public float flashInterval = 6f;     // Wait time between each flash
    public float flashIntensity = 1.5f;
    public bool startFlashingOnStart = true;

    private Renderer rend;
    private Material materialInstance;
    private Color originalColor;
    private Coroutine flashCoroutine;

    void Start()
    {
        rend = GetComponent<Renderer>();
        materialInstance = rend.material; // Clone material instance
        originalColor = materialInstance.color;

        if (startFlashingOnStart)
        {
            StartFlashing();
        }
    }

    private IEnumerator FlashRoutine()
    {
        while (true)
        {
            // Lerp to flashColor
            float timer = 0f;
            while (timer < flashDuration)
            {
                timer += Time.deltaTime;
                float t = timer / flashDuration;
                materialInstance.color = Color.Lerp(originalColor, flashColor * flashIntensity, t);
                yield return null;
            }

            // Lerp back to original
            timer = 0f;
            while (timer < flashDuration)
            {
                timer += Time.deltaTime;
                float t = timer / flashDuration;
                materialInstance.color = Color.Lerp(flashColor * flashIntensity, originalColor, t);
                yield return null;
            }

            yield return new WaitForSeconds(flashInterval);
        }
    }

    public void StartFlashing()
    {
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FlashRoutine());
    }

    public void StopFlashing()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            flashCoroutine = null;
        }

        if (materialInstance != null)
            materialInstance.color = originalColor;
    }
}
