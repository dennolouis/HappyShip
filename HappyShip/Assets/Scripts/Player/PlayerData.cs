using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] int rocketIndex;
    [SerializeField] int totalCoins;
    [SerializeField] List<int> totalStarsList;


    public PlayerData(Player player)
    {
        rocketIndex = player.GetRocketIndex();
        totalCoins = player.GetTotalCoins();
        totalStarsList = player.GetTotalStarList();
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
}
