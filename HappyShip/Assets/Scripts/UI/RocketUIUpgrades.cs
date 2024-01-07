using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUIUpgrades : MonoBehaviour
{
    [SerializeField] GameObject rocketsVisual;
    [SerializeField] GameObject rocketSelectionController;
    [SerializeField] GameObject healthVisual;
    [SerializeField] GameObject buyHealthBtn;

    GameObjectManager gameObjectManager;
    Player player;

    void Start()
    {
        // Assuming the GameObjectManager is attached to the same GameObject
        gameObjectManager = GetComponent<GameObjectManager>();
        // Hide all GameObjects at the start
        gameObjectManager.HideAllGameObjects();

        ShowRocketVisual();

        player = FindObjectOfType<Player>();
    }

    public void ShowRocketVisual()
    {
        // Show rocketsVisual and hide all others
        gameObjectManager.ShowGameObject(rocketsVisual);
        rocketSelectionController.SetActive(true);
    }

    public void ShowHealthVisual()
    {
        // Show healthVisual and hide all others
        gameObjectManager.ShowGameObject(healthVisual);
        buyHealthBtn.SetActive(true);
    }

    public void BuyHealth()
    {
        if(player.GetTotalCoins() > 50)
        {
            player.PayWithCoins(50);
            player.UpdateMaxLives();
            FindObjectOfType<CoinUI>().UpdateUI();
        }
    }

}

