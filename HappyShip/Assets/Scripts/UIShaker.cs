using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShaker : MonoBehaviour
{

    public RectTransform uiElement; // Reference to the UI element you want to shake
    float shakeDuration = 0.4f; // Duration of the shake in seconds
    float shakeIntensity = 0.5f;
    private Vector3 originalPosition;

    LevelHandler levelHandler;

    private void Awake()
    {
        originalPosition = uiElement.anchoredPosition;
    }

    private void Start()
    {
        levelHandler = FindObjectOfType<LevelHandler>();
    }

    public void Shake()
    {
        levelHandler.PlayerLockedLevelSound();
        StartCoroutine(ShakeUI());
    }

    private IEnumerator ShakeUI()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Generate a random offset for the shake
            Vector3 shakeOffset = Random.insideUnitCircle * shakeIntensity;

            // Apply the shake offset to the UI element's position
            uiElement.anchoredPosition = originalPosition + shakeOffset;

            // Increase the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Ensure the UI element returns to its original position
        uiElement.anchoredPosition = originalPosition;
    }
}
