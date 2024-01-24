using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] int rocketIndex;
    [SerializeField] List<bool> rockets;

    [SerializeField] int totalCoins;
    [SerializeField] List<int> totalStarsList;

    int maxLives = 3;
    [SerializeField] int lives = 3;

    [SerializeField] int adCount;

    int collectedCoins;
    int collectedStars;

    GameUI gameUI;
    SoundManager soundManager;

    private void Awake()
    {
        Load();
    }

    void Start()
    {
        gameUI = FindAnyObjectByType<GameUI>();
        soundManager = FindAnyObjectByType<SoundManager>();
        if (rocketIndex == 2)
            lives = maxLives * 2;
        if(rockets != null)
            rockets[0] = true;
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
        if(gameUI)
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

    public void PayWithCoins(int x)
    {
        totalCoins -= x;
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

        SaveStarLogic();

        totalCoins += collectedCoins;

        if (totalCoins > 3000)
            totalCoins = 3000;

        SaveSystem.SavePlayer(this);

    }

    void SaveStarLogic()
    {
        int levelIndex = FindObjectOfType<LevelChanger>().GetLevelIndex();

        if (levelIndex == 0)
            return;

        int savedStars = totalStarsList[levelIndex - 1];

        int playerMaxStars = collectedStars > savedStars ? collectedStars : savedStars;

        totalStarsList[levelIndex - 1] = playerMaxStars;
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if(data == null)
        {
            Debug.LogError("Null Player data. Using default values");
            return;
        }

        rocketIndex = data.GetRocketIndex();
        totalCoins = data.GetTotalCoins();
        totalStarsList = data.GetTotalStarList();
        adCount = data.GetAdCount();
        rockets = data.GetRockets();
        maxLives = data.GetMaxLives();

        lives = maxLives;
    }

    public int GetAdCount()
    {
        return adCount;
    }

    public void SetAdCount(int x)
    {
        adCount = x;
    }

    public bool CheckIfPlayerHasRocket()
    {
        print("rocket index is " + rocketIndex.ToString());
        return rockets[rocketIndex];
    }

    public bool BuyRocket()
    {
        if(totalCoins >= 200)
        {
            rockets[rocketIndex] = true;
            totalCoins -= 200;
            FindObjectOfType<CoinUI>().UpdateUI();
            return true;
        }
        return false;
    }

    public List<bool> GetRockets()
    {
        return rockets;
    }

    public void ResetCollectedStars()
    {
        collectedStars = 0;
    }

    public int GetMaxLives()
    {
        return maxLives;
    }

    public void UpdateMaxLives()
    {
        maxLives++;
    }

}
