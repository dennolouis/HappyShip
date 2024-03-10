using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip collectCoinClip;
    public AudioClip collectStarClip;
    public AudioClip collectHeartClip;
    public AudioClip uIButtonPressClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayCollectCoinSound()
    {
        PlaySound(collectCoinClip);
    }

    public void PlayCollectStarSound()
    {
        PlaySound(collectStarClip);
    }

    public void PlayCollectHeartSound()
    {
        PlaySound(collectHeartClip);
    }

    public void PlayUIButtonPressSound()
    {
        PlaySound(uIButtonPressClip);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Audio clip is missing!");
        }
    }
}