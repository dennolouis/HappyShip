using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;

    [SerializeField] int collectedStars;
    [SerializeField] GameObject[] stars;

    int levelNumber;
    Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayLevel);

        SetLevelNumber(2);
        ShowCollectedStars();
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

    void PlayLevel()
    {
        print(levelNumber);
    }

    void SetLevelNumber(int levelNumber)
    {
        this.levelNumber = levelNumber;
        levelText.text = levelNumber.ToString();
    }

}
