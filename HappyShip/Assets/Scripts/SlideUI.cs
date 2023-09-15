using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideUI : MonoBehaviour
{
    [SerializeField] float slideDistance = 20f; // Distance to slide down initially
    [SerializeField] float slideDuration = 1.5f; // Duration of the slide animation

    private RectTransform rectTransform;
    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.localPosition;
        targetPosition = originalPosition - new Vector3(0f, slideDistance, 0f);

        // Slide down initially
        rectTransform.localPosition = targetPosition;

        // Start the slide up animation
        StartCoroutine(SlideUp());
    }

    private IEnumerator SlideUp()
    {
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            rectTransform.localPosition = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the button ends up in the correct position even with small variations in deltaTime
        rectTransform.localPosition = originalPosition;
    }
}
