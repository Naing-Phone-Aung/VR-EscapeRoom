using UnityEngine;

public class SwordCut : MonoBehaviour
{
    public AudioSource swordAudioSource;
    public AudioClip swordClip;

    public AudioSource impactAudioSource;
    public AudioClip impactClip;

    private float lastSwordPlayTime = -1f;
    private float lastImpactPlayTime = -1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("RockPiece"))
        {
            float currentTime = Time.time;

            if (swordAudioSource != null && swordClip != null &&
                currentTime - lastSwordPlayTime >= swordClip.length)
            {
                swordAudioSource.clip = swordClip;
                swordAudioSource.Play();
                lastSwordPlayTime = currentTime;
            }

            if (impactAudioSource != null && impactClip != null &&
                currentTime - lastImpactPlayTime >= impactClip.length)
            {
                impactAudioSource.clip = impactClip;
                impactAudioSource.Play();
                lastImpactPlayTime = currentTime;
            }
        }
    }
}
