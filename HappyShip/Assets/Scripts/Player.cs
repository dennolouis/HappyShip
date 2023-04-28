using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] int lives = 5;
    [SerializeField] TMP_Text heartsTmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool HasLife()
    {
        return lives > 1;
    }

    public void UpdateLives(int x)
    {
        lives += x;
        heartsTmp.text = lives.ToString();
    }
}
