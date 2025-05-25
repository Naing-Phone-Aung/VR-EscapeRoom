using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class FadeInOnStart : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TMP_Text countdownText;
    public float countdownFadeDuration = 0.8f;
    public float finalFadeDuration = 1.5f;

    public DynamicMoveProvider dynamicMoveProvider;

    private string baseText;

    void Start()
    {
        baseText = countdownText.text;

        canvasGroup.alpha = 1f;

        if (dynamicMoveProvider != null)
            dynamicMoveProvider.enabled = false;

        StartCoroutine(CountdownThenFade());
    }

    private IEnumerator CountdownThenFade()
    {
        for (int i = 3; i >= 1; i--)
        {
            countdownText.alpha = 1f;
            countdownText.text = baseText + " " + i + "...";

            float t = 0f;
            while (t < countdownFadeDuration)
            {
                t += Time.deltaTime;
                countdownText.alpha = Mathf.Lerp(1f, 0f, t / countdownFadeDuration);
                yield return null;
            }

            countdownText.alpha = 0f;
        }

        if (dynamicMoveProvider != null)
            dynamicMoveProvider.enabled = true;

        float fadeTimer = 0f;
        while (fadeTimer < finalFadeDuration)
        {
            fadeTimer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, fadeTimer / finalFadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }
}
