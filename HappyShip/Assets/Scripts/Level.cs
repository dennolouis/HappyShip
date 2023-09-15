using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;

    [SerializeField] GameObject[] stars;
    [SerializeField] GameObject[] greyStars;

    [SerializeField] GameObject lockUI;

    int collectedStars;
    int neededStars;

    public RectTransform uiElement; // Reference to the UI element you want to shake
    float shakeDuration = 0.4f; // Duration of the shake in seconds
    float shakeIntensity = 0.5f;
    private Vector3 originalPosition;

    LevelHandler levelHandler;
    
    int levelNumber;
    Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayLevel);
        btn.interactable = false;
        lockUI.GetComponent<Button>().onClick.AddListener(Shake);
        originalPosition = uiElement.anchoredPosition;
    }

    void Start()
    {
        levelHandler = FindObjectOfType<LevelHandler>();      
    }

    void ShowCollectedStars()
    {
        if (stars.Length < collectedStars)
        {
            Debug.LogError("stars.Length < collectedStars");
            return;
        }

        for(int i = 0; i < collectedStars; i++)
        {
            stars[i].SetActive(true);
        }
    }

    public void SetCollectedStars(int numStarsCollected)
    {
        collectedStars = numStarsCollected;
    }

    void PlayLevel()
    {
        levelHandler.PlayerSelectLevelSound();
        print(levelNumber);
        FindObjectOfType<LevelChanger>().FadeToLevel(levelNumber);
    }

    public void SetLevelNumber(int levelNumber)
    {
        levelText.text = levelNumber.ToString();
        this.levelNumber = levelNumber;
    }

    public void SetNeededStars(int neededStars)
    {
        this.neededStars = neededStars;
    }

    public void HandleLock(int totalPlayerStars)
    {
        if(totalPlayerStars >= neededStars)
        {
            lockUI.SetActive(false);
            btn.interactable = true;
            ShowCollectedStars();
        }
        else
        {
            levelText.text = "";
            foreach(GameObject greyStar in greyStars)
            {
                greyStar.SetActive(false);
            }
        }
    }

    void Shake()
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


