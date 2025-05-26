using UnityEngine;

public class UIFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;

    void Update()
    {
        if (playerCamera == null) return;
        transform.LookAt(playerCamera);
        transform.Rotate(0, 180f, 0);
        Vector3 euler = transform.eulerAngles;
        transform.eulerAngles = new Vector3(0, euler.y, 0);
    }
}
