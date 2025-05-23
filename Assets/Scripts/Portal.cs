using UnityEngine;

public class Portal : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0); // rotates the portal
    }
}

