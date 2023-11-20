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
    int adCount;


    public PlayerData(Player player)
    {
        rocketIndex = player.GetRocketIndex();
        totalCoins = player.GetTotalCoins();
        totalStarsList = player.GetTotalStarList();
        adCount = player.GetAdCount();
        rockets = player.GetRockets();
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

}
