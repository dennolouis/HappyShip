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

    [SerializeField] TMP_Text healthCost;
    [SerializeField] TMP_Text ammoCost;

    [SerializeField] GameObject buyAmmoBtn;

    GameObjectManager gameObjectManager;
    Player player;
    SoundManager soundManager;

    int MAX_LIVES = 7;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

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
        int cost = GetHealthCost();
        if(player.GetTotalCoins() >= cost)
        {
            player.PayWithCoins(cost);
            player.UpdateMaxLives();
            FindObjectOfType<CoinUI>().UpdateUI();
            UpdateMaxLivesTMP();
            soundManager.PlayCollectCoinSound();
        }
    }

    public void BuyAmmo()
    {
        int cost = GetBulletCost();
        if (player.GetTotalCoins() > cost)
        {
            player.PayWithCoins(cost);
            player.UpdateAmmo();
            FindObjectOfType<CoinUI>().UpdateUI();
            UpdateAmmoTMP();
            soundManager.PlayCollectCoinSound();
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

        ammoCost.text = GetBulletCost().ToString();

        if (ammo >= 3)
        {
            buyAmmoBtn.GetComponent<Button>().interactable = false;
            ammoCost.text = "Max";
        }

    }

    void UpdateMaxLivesTMP()
    {
        int playerMaxLives = player.GetMaxLives();

        maxLives.text = playerMaxLives.ToString();

        healthCost.text = GetHealthCost().ToString();

        if (playerMaxLives >= MAX_LIVES)
        {
            maxLives.text += " MAX";
            healthCost.text = "Max";
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

    public int GetHealthCost()
    {
        int[] costs = { 25, 50, 75, 100, 100};
        int costIdx = player.GetMaxLives() - 3;

        return costs[costIdx];
    }

    public int GetBulletCost()
    {
        int[] costs = { 75, 150, 150};
        int costIdx = player.GetAmmo() - 1;

        return costs[costIdx];
    }
}

