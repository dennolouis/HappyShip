using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggestionArrow : MonoBehaviour
{

    Player player;
    RocketUIUpgrades upgrades;

    void Start()
    {
        player = FindObjectOfType<Player>();
        upgrades = FindObjectOfType<RocketUIUpgrades>();

        gameObject.SetActive(PlayerCanAffordRocket() || PlayerCanAffordHealth() || PlayerCanAffordAmmo());
    }

    bool PlayerCanAffordRocket()
    {
        return player.GetRockets().Contains(false) && player.GetTotalCoins() >= 200;
    }

    bool PlayerCanAffordHealth()
    {
        return player.GetMaxLives() < 7 && player.GetTotalCoins() >= upgrades.GetHealthCost();
    }

    bool PlayerCanAffordAmmo()
    {
        return player.GetAmmo() < 3 && player.GetTotalCoins() >= upgrades.GetBulletCost();
    }

    public void HideArrow()
    {
        gameObject.SetActive(false);
    }
}
