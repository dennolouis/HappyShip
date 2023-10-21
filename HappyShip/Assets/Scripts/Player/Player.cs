using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] int rocketIndex;

    [SerializeField] int lives = 5;

    [SerializeField] int collectedCoins;
    [SerializeField] int collectedStars;

    [SerializeField] int totalCoins;
    [SerializeField] List<int> totalStarsList;

    GameUI gameUI;
    SoundManager soundManager;

    void Start()
    {
        gameUI = FindAnyObjectByType<GameUI>();
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    public int GetRocketIndex()
    {
        return rocketIndex;
    }

    public void SetRocketIndex(int i)
    {
        rocketIndex = i;
    }

    public bool HasLife()
    {
        return lives > 1;
    }

    public void UpdateLives(int x)
    {
        lives += x;
        gameUI.SetHearts(lives);

        if(x > 0)
            soundManager.PlayCollectHeartSound(); //play if increasing health
    }

    public int GetLives()
    {
        return lives;
    }

    public void CollectCoin()
    {
        collectedCoins++;
        soundManager.PlayCollectCoinSound();
    }

    public void CollectStar()
    {
        collectedStars++;
        soundManager.PlayCollectStarSound();
    }

    public List<int> GetTotalStarList()
    {
        return totalStarsList;
    }

    public int GetTotalStars()
    {
        int sum = 0;

        foreach(int stars in totalStarsList)
        {
            sum += stars;
        }

        return sum;
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public void Save()
    {
        print("Player collected " + collectedStars.ToString() + " stars in level " + FindObjectOfType<LevelChanger>().GetLevelIndex());
        print("Coins: " + collectedCoins.ToString());

    }



}
