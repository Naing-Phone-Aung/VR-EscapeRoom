using UnityEngine;
using TMPro;

public class ToggleLight : MonoBehaviour
{
    public Light currentLight = null;
    public bool isOn = false;
    public Collider targetCollider = null;

    // Optional: reference to the text to force-hide
    public TextMeshPro revealText;

    void Start()
    {
        currentLight.enabled = isOn;
        if (targetCollider != null)
            targetCollider.enabled = isOn;

        if (revealText != null)
            SetAlpha(revealText, isOn ? 1f : 0f);
    }

    public void ToggleLightOnOff()
    {
        isOn = !isOn;
        currentLight.enabled = isOn;

        if (targetCollider != null)
            targetCollider.enabled = isOn;

        if (!isOn && revealText != null)
        {
            // force hide text when light off
            SetAlpha(revealText, 0f);
        }
    }

    private void SetAlpha(TextMeshPro tmp, float alpha)
    {
        Color c = tmp.faceColor;
        c.a = alpha;
        tmp.faceColor = c;
    }
}
