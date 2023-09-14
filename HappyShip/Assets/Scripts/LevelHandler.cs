using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] List<Level> levels;
    [SerializeField] List<int> neededStars;

    [SerializeField] AudioClip selectLevelSound;
    [SerializeField] AudioClip lockedLevelSound;

    AudioSource audioSource;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Player player = FindObjectOfType<Player>();
        List<int> collectedStarList = player.GetTotalStarList();
        int playerCollectedStars = player.GetTotalStars();
        
        for(int i = 0; i < levels.Count; i++)
        {
            levels[i].SetLevelNumber(i + 1);
            levels[i].SetNeededStars(neededStars[i]);
            levels[i].SetCollectedStars(collectedStarList[i]);
            levels[i].HandleLock(playerCollectedStars);
        }
    }


    public void PlayerSelectLevelSound()
    {
        audioSource.PlayOneShot(selectLevelSound);
    }

    public void PlayerLockedLevelSound()
    {
        audioSource.PlayOneShot(lockedLevelSound);
    }

}
