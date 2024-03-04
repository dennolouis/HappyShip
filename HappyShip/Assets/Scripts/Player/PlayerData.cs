using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] int rocketIndex;
    [SerializeField] List<bool> rockets;
    [SerializeField] int totalCoins;
    [SerializeField] List<int> totalStarsList;
    [SerializeField] int ammo;
    int adCount;
    int maxLives;

    bool updateRocket = false;


    public PlayerData(Player player)
    {
        rocketIndex = player.GetRocketIndex();
        totalCoins = player.GetTotalCoins();
        totalStarsList = player.GetTotalStarList();
        adCount = player.GetAdCount();
        rockets = player.GetRockets();
        maxLives = player.GetMaxLives();
        ammo = player.GetAmmo();
        updateRocket = player.GetUpdateRocket();
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public List<int> GetTotalStarList()
    {
        return totalStarsList;
    }

    public int GetRocketIndex()
    {
        return rocketIndex;
    }

    public int GetAdCount()
    {
        return adCount;
    }

    public List<bool> GetRockets()
    {
        return rockets;
    }

    public int GetMaxLives()
    {
        return maxLives;
    }

    public int GetAmmo()
    {
        return ammo > 0 ? ammo : 1;
    }

    public void SetAmmo(int x)
    {
        ammo = x > 0 ? x : 1;
    }

    public bool GetUpdateRocket()
    {
        return updateRocket;
    }

    public void SetUpdateRocket(bool val)
    {
        updateRocket = val;
    }
}
