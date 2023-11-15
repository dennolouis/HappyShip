using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuiteButton : MonoBehaviour
{

    public void Quit()
    {
        LevelChanger levelChanger = FindObjectOfType<LevelChanger>();

        if(levelChanger != null)
        {
            levelChanger.FadeToLevel(0);
        }
    }

}
