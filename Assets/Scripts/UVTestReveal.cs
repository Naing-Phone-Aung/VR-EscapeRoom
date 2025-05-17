using UnityEngine;
using TMPro;

public class UVTextReveal : MonoBehaviour
{
    public TextMeshPro tmpText;
    public float visibleAlpha = 1f;
    public float hiddenAlpha = 0f;

    void Start()
    {
        SetAlpha(hiddenAlpha); // Start invisible
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UVLight"))
        {
            SetAlpha(visibleAlpha);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UVLight"))
        {
            SetAlpha(hiddenAlpha);
        }
    }

    void SetAlpha(float alphaValue)
    {
        Color currentColor = tmpText.faceColor;
        currentColor.a = alphaValue;
        tmpText.faceColor = currentColor;
    }
}
