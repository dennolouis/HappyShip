using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject[] menus; // Array to hold your UI menus
    public float slideSpeed = 0.5f; // Adjust this value to control the sliding speed

    private RectTransform[] menuRects; // Array to hold the RectTransform components of the menus
    private int currentMenuIndex = 0; // Index of the currently active menu

    void Start()
    {
        menuRects = new RectTransform[menus.Length];

        for (int i = 0; i < menus.Length; i++)
        {
            menuRects[i] = menus[i].GetComponent<RectTransform>();
        }

        //ShowMenu(currentMenuIndex); // Show the initial menu
    }

    public void SwitchToMenu(int targetMenuIndex)
    {
        if (targetMenuIndex < 0 || targetMenuIndex >= menus.Length || targetMenuIndex == currentMenuIndex)
        {
            return; // Invalid index or already on the target menu
        }

        MoveMenuOffScreen(currentMenuIndex, GetSlideDirection(targetMenuIndex)); // Move the current menu off the screen
        currentMenuIndex = targetMenuIndex;
        MoveMenuOnScreen(currentMenuIndex, GetSlideDirection(targetMenuIndex)); // Move the new menu on the screen
    }

    private void MoveMenuOnScreen(int menuIndex, SlideDirection direction)
    {
        RectTransform rectTransform = menuRects[menuIndex];
        Vector2 targetPosition = Vector2.zero;

        switch (direction)
        {
            case SlideDirection.Up:
                targetPosition.y = 0;
                break;
            case SlideDirection.Down:
                targetPosition.y = 0;
                break;
            case SlideDirection.Left:
                targetPosition.x = 0;
                break;
            case SlideDirection.Right:
                targetPosition.x = 0;
                break;
        }

        LeanTween.move(rectTransform, targetPosition, slideSpeed).setEase(LeanTweenType.easeInOutQuad);
    }

    private void MoveMenuOffScreen(int menuIndex, SlideDirection direction)
    {
        RectTransform rectTransform = menuRects[menuIndex];
        Vector2 targetPosition = Vector2.zero;

        switch (direction)
        {
            case SlideDirection.Up:
                targetPosition.y = rectTransform.rect.height;
                break;
            case SlideDirection.Down:
                targetPosition.y = -rectTransform.rect.height;
                break;
            case SlideDirection.Left:
                targetPosition.x = -rectTransform.rect.width;
                break;
            case SlideDirection.Right:
                targetPosition.x = rectTransform.rect.width;
                break;
        }

        LeanTween.move(rectTransform, targetPosition, slideSpeed).setEase(LeanTweenType.easeInOutQuad);
    }

    private void ShowMenu(int menuIndex)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == menuIndex);
        }
    }

    private SlideDirection GetSlideDirection(int targetMenuIndex)
    {
        // You can implement your logic to determine the slide direction based on menu indices.
        // For now, let's assume alternating directions for demonstration purposes.
        return targetMenuIndex % 2 == 0 ? SlideDirection.Left : SlideDirection.Right;
    }
}

public enum SlideDirection
{
    Up,
    Down,
    Left,
    Right
}
