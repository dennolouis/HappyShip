using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideButton : MonoBehaviour
{
    [SerializeField] float slideDistance = 20f; // Distance to slide up
    [SerializeField] float slideDuration = 1f; // Duration of the slide animation

    private RectTransform rectTransform;
    private Vector3 originalPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.localPosition;

        // Get the Button component and subscribe to its onClick event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogWarning("No Button component found on the game object.");
        }
    }

    public void OnButtonClick()
    {
        // Start the slide animation
        StartCoroutine(SlideUp());
    }

    private IEnumerator SlideUp()
    {
        float elapsedTime = 0f;
        Vector3 targetPosition = originalPosition + new Vector3(0f, slideDistance, 0f);

        while (elapsedTime < slideDuration)
        {
            rectTransform.localPosition = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the button ends up in the correct position even with small variations in deltaTime
        rectTransform.localPosition = targetPosition;
    }
}
