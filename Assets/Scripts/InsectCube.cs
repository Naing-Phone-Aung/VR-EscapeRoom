using UnityEngine;

public class InsectCube : MonoBehaviour
{
    public int currentIndex = 0; 
    public Material[] Materials; 
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
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
}
