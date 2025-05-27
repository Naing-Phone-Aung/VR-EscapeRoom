using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Transform respawnPoint; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Invoke(nameof(Respawn), 1f);
        }
    }

    private void Respawn()
    {
        if (respawnPoint == null)
        {
            Debug.LogWarning("Respawn point not assigned.");
            return;
        }

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }
}
