using UnityEngine;

public class BallFallReset : MonoBehaviour
{
    public GameObject mazeToMove;
    public Transform respawnLocation;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MazeGround"))
        {
            if (mazeToMove != null && respawnLocation != null)
            {
                mazeToMove.transform.position = respawnLocation.position;
                transform.position = respawnLocation.position ; 
            }
        }
    }
}
