using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public GameObject objectToEnable1;
    public GameObject objectToEnable2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExitBlock"))
        {
            if (objectToEnable1 != null)
            {
                objectToEnable1.SetActive(true);

                AudioSource portalSound = objectToEnable1.GetComponent<AudioSource>();
                if (portalSound != null) portalSound.Play();
            }

            if (objectToEnable2 != null)
            {
                objectToEnable2.SetActive(true);
            }
        }
    }
}
