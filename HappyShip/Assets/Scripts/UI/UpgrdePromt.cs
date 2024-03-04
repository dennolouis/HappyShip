using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrdePromt : MonoBehaviour
{

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        gameObject.SetActive(player.GetTotalStars() > 0 && player.GetTotalStars() <= 3 && !player.GetUpdateRocket());
    }

    public void HidePrompt()
    {
        player.SetUpdateRocket(true); //ensures promt only shows once
        gameObject.SetActive(false);
    }
}
