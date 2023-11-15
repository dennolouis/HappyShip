using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PulseUI : MonoBehaviour
{
    Transform uiItemTransform; // Reference to the UI item's Transform component
    public float pulseDuration = 1.0f; // Duration of one pulse cycle
    public float minScale = 0.8f; // Minimum scale during the pulse
    public float maxScale = 1.2f; // Maximum scale during the pulse

    private Vector3 originalScale; // Store the original scale for resetting

    private void Start()
    {
        uiItemTransform = gameObject.transform;

        // Ensure a reference to the UI item's Transform is set
        if (uiItemTransform == null)
        {
            Debug.LogError("UI Item Transform is not set. Please assign it in the Inspector.");
            enabled = false; // Disable the script if the reference is missing
            return;
        }

        originalScale = uiItemTransform.localScale;

        // Start the pulsing coroutine
        StartCoroutine(Pulse());
    }

    private IEnumerator Pulse()
    {
        while (true)
        {
            float timeElapsed = 0f;

            // Pulse up
            while (timeElapsed < pulseDuration / 2)
            {
                float t = timeElapsed / (pulseDuration / 2);
                uiItemTransform.localScale = Vector3.Lerp(originalScale * minScale, originalScale * maxScale, t);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Pulse down
            timeElapsed = 0f;
            while (timeElapsed < pulseDuration / 2)
            {
                float t = timeElapsed / (pulseDuration / 2);
                uiItemTransform.localScale = Vector3.Lerp(originalScale * maxScale, originalScale * minScale, t);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Reset to original scale
            uiItemTransform.localScale = originalScale;

            // Wait for a moment before starting the next pulse
            yield return new WaitForSeconds(0f); // You can adjust the wait time between pulses
        }
    }
}
