using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    [SerializeField] GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
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



}
