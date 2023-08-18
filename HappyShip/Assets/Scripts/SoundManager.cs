using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip collectCoinClip;
    public AudioClip collectStarClip;
    public AudioClip collectHeartClip;

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