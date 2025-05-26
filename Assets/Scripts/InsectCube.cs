using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class InsectCube : MonoBehaviour
{
    public int currentIndex = 0; 
    public Material[] Materials; 
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        // Subscribe to the trigger interaction
        var interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnTriggerPressed);
        }
        UpdateVisual();
    }

    public void CycleType()
    {
        currentIndex = (currentIndex + 1) % Materials.Length;
        UpdateVisual();
        InsectManager.Instance.CheckSequence();
    }

    private void UpdateVisual()
    {
        meshRenderer.material = Materials[currentIndex];
    }

    void OnDestroy()
    {
        var interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnTriggerPressed);
        }
    }

    private void OnTriggerPressed(SelectEnterEventArgs args)
    {
        CycleType();
    }

}
