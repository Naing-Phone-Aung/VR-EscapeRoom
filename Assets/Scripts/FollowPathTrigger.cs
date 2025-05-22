using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class FollowPathTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    private Transform rigRoot;

    private Coroutine trapCoroutine;
    private Coroutine blinkCoroutine;
    private bool isOnTrap = false;

    public CanvasGroup warningCanvas;
    private AudioSource audioSource;

    private DynamicMoveProvider moveProvider;
    public float normalSpeed = 2.5f;
    public float slowSpeed = 0.3f;

    private void Start()
    {
        // Get XR Rig root and components
        rigRoot = transform.root;
        audioSource = GetComponent<AudioSource>();
        moveProvider = rigRoot.GetComponentInChildren<DynamicMoveProvider>();

        if (warningCanvas != null)
            warningCanvas.alpha = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap") && !isOnTrap)
        {
            isOnTrap = true;

            ShowWarning(true);

            if (audioSource != null && !audioSource.isPlaying)
                audioSource.Play();

            if (moveProvider != null)
            {
                moveProvider.moveSpeed = slowSpeed;
            }

            trapCoroutine = StartCoroutine(WaitAndRespawn(3f));
        }
        else if (other.CompareTag("Goal"))
        {
            Debug.Log("You finished the level.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trap") && isOnTrap)
        {
            Debug.Log("Exited trap area");
            isOnTrap = false;

            if (audioSource != null && audioSource.isPlaying)
                audioSource.Stop();

            if (moveProvider != null)
            {
                moveProvider.moveSpeed = normalSpeed;
                Debug.Log("Restored player speed" );
            }

            if (trapCoroutine != null)
                StopCoroutine(trapCoroutine);

            ShowWarning(false);
        }
    }

    private IEnumerator WaitAndRespawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (isOnTrap)
        {
            Debug.Log("Stayed on trap for 3 seconds. Respawning");

            if (audioSource != null && audioSource.isPlaying)
                audioSource.Stop();

            if (moveProvider != null)
            {
                moveProvider.moveSpeed = normalSpeed;
                Debug.Log("Reset speed after respawn");
            }

            ShowWarning(false);
            RespawnPlayer();
        }
    }

    private void ShowWarning(bool show)
    {
        if (warningCanvas == null) return;

        if (show)
        {
            if (blinkCoroutine == null)
                blinkCoroutine = StartCoroutine(BlinkCanvas());
        }
        else
        {
            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);
                blinkCoroutine = null;
            }

            warningCanvas.alpha = 0f;
        }
    }

    private IEnumerator BlinkCanvas()
    {
        while (true)
        {
            warningCanvas.alpha = 0f;
            yield return new WaitForSeconds(0.4f);
            warningCanvas.alpha = 1f;
            yield return new WaitForSeconds(0.4f);
        }
    }

    private void RespawnPlayer()
    {
        if (rigRoot != null && respawnPoint != null)
        {
            Vector3 offset = rigRoot.position - transform.position;
            rigRoot.position = respawnPoint.position + offset;
        }
    }
}
