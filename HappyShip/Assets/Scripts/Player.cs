using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int lives = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool HasLife()
    {
        return lives > 0;
    }

    public void UpdateLives(int x)
    {
        lives += x;
    }
}
