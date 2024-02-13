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
    [SerializeField] GameObject ammoVisual;

    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text maxLives;
    [SerializeField] TMP_Text ammoText;

    [SerializeField] GameObject buyAmmoBtn;

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
        UpdateAmmoTMP();

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

    public void ShowAmmoVisual()
    {
        gameObjectManager.ShowGameObject(ammoVisual);
    }

    public void BuyHealth()
    {
        if(player.GetTotalCoins() >= 50)
        {
            player.PayWithCoins(50);
            player.UpdateMaxLives();
            FindObjectOfType<CoinUI>().UpdateUI();
            UpdateMaxLivesTMP();
        }
    }

    public void BuyAmmo()
    {
        if (player.GetTotalCoins() > 75)
        {
            player.PayWithCoins(75);
            player.UpdateAmmo();
            FindObjectOfType<CoinUI>().UpdateUI();
            UpdateAmmoTMP();
        }
    }

    public void SetDescription(string description)
    {
        this.description.text = description;
    }

    public void UpdateAmmoTMP()
    {
        int ammo = player.GetAmmo();
        ammoText.text = ammo.ToString();

        if(ammo >= 3)
        {
            buyAmmoBtn.GetComponent<Button>().interactable = false;
        }
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

