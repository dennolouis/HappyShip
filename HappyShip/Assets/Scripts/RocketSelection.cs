using UnityEngine;
using UnityEngine.UI; // Add this for accessing UI components
using System.Collections.Generic;

public class RocketSelection : MonoBehaviour
{
    [SerializeField] List<GameObject> rockets;
    [SerializeField] GameObject rocketLock;
    private int currentIndex = 0;
    private GameObject previousRocket;

    [SerializeField] Button nextButton;
    [SerializeField] Button prevButton;

    AudioSource audioSource;

    Player player;

    RocketUIUpgrades rocketUIUpgrades;

    string[] rocketDescriptions = { "Collects double the coins",
                                    "Shoots double the bullets",
                                    "Starts off with double health"};

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        rocketUIUpgrades = FindObjectOfType<RocketUIUpgrades>();

        currentIndex = player.GetRocketIndex();

        DisableAllRockets();
        EnableCurrentRocket();

        // Add click event listeners
        nextButton.onClick.AddListener(Next);
        prevButton.onClick.AddListener(Previous);

        UpdateRocketSelectionUI();
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
        player.SetRocketIndex(currentIndex);
        EnableCurrentRocket();
        UpdateRocketSelectionUI();
        audioSource.Play();
    }

    public void Previous()
    {
        DisablePreviousRocket();
        currentIndex = (currentIndex - 1 + rockets.Count) % rockets.Count;
        player.SetRocketIndex(currentIndex);
        EnableCurrentRocket();
        UpdateRocketSelectionUI();
        audioSource.Play();
    }

    public void DisplayRocketDescription()
    {
        rocketUIUpgrades.SetDescription(rocketDescriptions[currentIndex]);
    }

    private void EnableCurrentRocket()
    {
        rockets[currentIndex].SetActive(true);
        previousRocket = rockets[currentIndex];

        DisplayRocketDescription();
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

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public void UpdateRocketSelectionUI()
    {
        rocketLock.SetActive(!player.CheckIfPlayerHasRocket());
    }
}
