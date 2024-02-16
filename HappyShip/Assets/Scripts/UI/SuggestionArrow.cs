using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggestionArrow : MonoBehaviour
{

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        gameObject.SetActive(PlayerCanAffordRocket() || PLayerCanAffordHealth() || PlayerCanAffordAmmo());
    }

    bool PlayerCanAffordRocket()
    {
        return player.GetRockets().Contains(false) && player.GetTotalCoins() >= 200;
    }

    bool PLayerCanAffordHealth()
    {
        return player.GetMaxLives() < 7 && player.GetTotalCoins() >= 50;
    }

    bool PlayerCanAffordAmmo()
    {
        return player.GetAmmo() < 3 && player.GetTotalCoins() >= 75;
    }

    public void HideArrow()
    {
        gameObject.SetActive(false);
    }
}
