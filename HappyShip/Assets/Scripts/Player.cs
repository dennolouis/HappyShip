using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int lives = 5;

    GameUI gameUI;
    // Start is called before the first frame update
    void Start()
    {
        gameUI = FindAnyObjectByType<GameUI>();
    }

    public bool HasLife()
    {
        return lives > 1;
    }

    public void UpdateLives(int x)
    {
        lives += x;
        gameUI.SetHearts(lives);
    }

    public int GetLives()
    {
        return lives;
    }

}
