using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] GameObject mutedButton;


    void Start()
    {
        mutedButton.SetActive(AudioListener.pause);
    }

    public void Mute()
    {
        AudioListener.pause = true;
        mutedButton.SetActive(true);
    }

    public void UnMute()
    {
        AudioListener.pause = false;
        mutedButton.SetActive(false);
    }
}
