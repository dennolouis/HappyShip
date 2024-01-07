using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    AudioSource audioSource;

    Player player;

    RocketSelection rocketSelection;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        rocketSelection = FindObjectOfType<RocketSelection>();
    }

    public void BuyRocket()
    {
        bool playerBoughtRocket = player.BuyRocket();
        rocketSelection.UpdateRocketSelectionUI();
        if (playerBoughtRocket && audioSource)
        {
            audioSource.Play();
        }
        else if(!playerBoughtRocket)
        {
            GetComponent<UIShaker>().Shake();
        }
    }

}
