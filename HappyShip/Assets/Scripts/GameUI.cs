using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{

    [SerializeField] GameObject continueButton;
    [SerializeField] TMP_Text heartsTmp;

    Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        SetHearts(player.GetLives());

        HideContinueButton();
    }


    public void ShowContinueButton()
    {
        continueButton.SetActive(true);
    }

    public void HideContinueButton()
    {
        continueButton.SetActive(false);
    }


    public void SetHearts(int x)
    {
        heartsTmp.text = x.ToString();
    }


}
