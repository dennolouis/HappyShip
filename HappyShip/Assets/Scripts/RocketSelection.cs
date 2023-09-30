using UnityEngine;
using UnityEngine.UI; // Add this for accessing UI components
using System.Collections.Generic;

public class RocketSelection : MonoBehaviour
{
    [SerializeField] List<GameObject> rockets;
    private int currentIndex = 0;
    private GameObject previousRocket;

    [SerializeField] Button nextButton;
    [SerializeField] Button prevButton;

    void Start()
    {
        DisableAllRockets();
        EnableCurrentRocket();

        // Add click event listeners
        nextButton.onClick.AddListener(Next);
        prevButton.onClick.AddListener(Previous);
    }

    void OnDestroy()
    {
        // Remove click event listeners to prevent memory leaks
        nextButton.onClick.RemoveListener(Next);
        prevButton.onClick.RemoveListener(Previous);
    }

    public void Next()
    {
        DisablePreviousRocket();
        currentIndex = (currentIndex + 1) % rockets.Count;
        EnableCurrentRocket();
    }

    public void Previous()
    {
        DisablePreviousRocket();
        currentIndex = (currentIndex - 1 + rockets.Count) % rockets.Count;
        EnableCurrentRocket();
    }

    private void EnableCurrentRocket()
    {
        rockets[currentIndex].SetActive(true);
        previousRocket = rockets[currentIndex];
    }

    private void DisablePreviousRocket()
    {
        if (previousRocket != null && previousRocket.activeSelf)
        {
            previousRocket.SetActive(false);
        }
    }

    private void DisableAllRockets()
    {
        foreach (var rocket in rockets)
        {
            rocket.SetActive(false);
        }
    }
}