using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuiteButton : MonoBehaviour
{

    public void Quit()
    {
        LevelChanger levelChanger = FindObjectOfType<LevelChanger>();

        SavePlayerCollectedCoins();
        if(levelChanger != null)
        {
            levelChanger.FadeToLevel(0);
        }
    }

    void SavePlayerCollectedCoins()
    {
        Player player = FindObjectOfType<Player>();

        if(player)
        {
            player.ResetCollectedStars();
            player.Save();
        }
    }

}
