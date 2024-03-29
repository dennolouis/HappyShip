using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;

    private void Awake()
    {
        TestSingleton();
    }

    void TestSingleton()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLeaderboard(int score)
    {
        int level = FindObjectOfType<LevelChanger>().GetLevelIndex();
        switch (level)
        {
            case 1:
                Leaderboards.lvl1.SubmitScore(score);
                break;
            case 2:
                Leaderboards.lvl2.SubmitScore(score);
                break;
            case 3:
                Leaderboards.lvl3.SubmitScore(score);
                break;
            case 4:
                Leaderboards.lvl4.SubmitScore(score);
                break;
            case 5:
                Leaderboards.lvl5.SubmitScore(score);
                break;
            case 6:
                Leaderboards.lvl6.SubmitScore(score);
                break;
            case 7:
                Leaderboards.lvl7.SubmitScore(score);
                break;
            case 8:
                Leaderboards.lvl8.SubmitScore(score);
                break;
            case 9:
                Leaderboards.lvl9.SubmitScore(score);
                break;
            default:
                Debug.LogError("not a valid level: " + level.ToString());
                break;

        }
    }
}
