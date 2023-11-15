using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        gameObject.SetActive(true);
        Time.timeScale = 1;
    }

}
