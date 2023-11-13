using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    TMP_Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TMP_Text>();
        UpdateUI();
        
    }

    public void UpdateUI()
    {
        string playerCoinsString = FindObjectOfType<Player>().GetTotalCoins().ToString();
        txt.SetText(playerCoinsString);
    }

}
