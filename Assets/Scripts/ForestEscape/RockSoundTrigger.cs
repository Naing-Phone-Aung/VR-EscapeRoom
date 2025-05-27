using UnityEngine;

public class RockSoundTrigger : MonoBehaviour
{
    public AudioSource collapseSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            collapseSound?.Play();
        }
    }
}
