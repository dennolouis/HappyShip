using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketUIUpgrades : MonoBehaviour
{
    [SerializeField] GameObject rocketsVisual;
    [SerializeField] GameObject rocketSelectionController;
    [SerializeField] GameObject healthVisual;
    [SerializeField] GameObject buyHealthBtn;
    [SerializeField] Slider healthSlider;

    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text maxLives;

    GameObjectManager gameObjectManager;
    Player player;

    int MAX_LIVES = 7;

    void Start()
    {
        // Assuming the GameObjectManager is attached to the same GameObject
        gameObjectManager = GetComponent<GameObjectManager>();
        // Hide all GameObjects at the start
        gameObjectManager.HideAllGameObjects();

        ShowRocketVisual();

        player = FindObjectOfType<Player>();

        UpdateMaxLivesTMP();

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
            UpdateMaxLivesTMP();
        }
    }

    public void SetDescription(string description)
    {
        this.description.text = description;
    }

    void UpdateMaxLivesTMP()
    {
        int playerMaxLives = player.GetMaxLives();

        maxLives.text = playerMaxLives.ToString();

        if (playerMaxLives >= MAX_LIVES)
        {
            maxLives.text += " MAX";
            buyHealthBtn.GetComponent<Button>().interactable = false;
        }

        UpdateHealthSlider();
          
    }

    void UpdateHealthSlider()
    {
        float playerMaxLives = player.GetMaxLives();
        float slideValue = (playerMaxLives - 3) / (float)(MAX_LIVES - 3);

        healthSlider.value = slideValue;
    }
}

