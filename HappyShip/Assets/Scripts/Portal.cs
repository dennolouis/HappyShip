using UnityEngine;

public class Portal : MonoBehaviour
{
    // Public field to set the destination portal in the Unity Editor
    [SerializeField] Portal destinationPortal;

    [SerializeField] GameObject teleportEffect;

    // Static variable to track whether the player has just been teleported
    private static bool justTeleported = false;

    // Cooldown duration to prevent immediate re-teleportation
    public float teleportCooldown = 1.0f;
    private float lastTeleportTime;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player" and if the player has not just been teleported
        if (other.CompareTag("Player") && !justTeleported && Time.time - lastTeleportTime > teleportCooldown)
        {
            // Teleport the player to the destination portal
            TeleportPlayer(other.transform);
            // Set justTeleported to true
            justTeleported = true;
            // Update the last teleportation time
            lastTeleportTime = Time.time;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Delay resetting justTeleported to false to avoid immediate re-triggering
            StartCoroutine(ResetJustTeleported());
        }
    }

    private System.Collections.IEnumerator ResetJustTeleported()
    {
        // Introduce a delay before resetting justTeleported to false
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed

        // Reset justTeleported to false
        justTeleported = false;
    }

    private void TeleportPlayer(Transform playerTransform)
    {
        // Disable the player's Rigidbody to prevent unwanted physics interactions during teleportation
        Rigidbody playerRigidbody = playerTransform.GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.isKinematic = true;
        }

        // Move the player to the destination portal's position
        playerTransform.position = destinationPortal.transform.position;
        destinationPortal.ShowTeleportEffect();

        // Enable the player's Rigidbody back
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false;
        }
    }

    public void ShowTeleportEffect()
    {
        if (teleportEffect)
        {
            GameObject effect = Instantiate(teleportEffect, transform.position, transform.rotation);
            Destroy(effect, 8f);
        }
    }
}
