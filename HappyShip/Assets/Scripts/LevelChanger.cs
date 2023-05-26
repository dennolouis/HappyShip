using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] Animator animator;

    int levelToLoad;

    public void FadeToLevel(int levelIndex)
    {
        Time.timeScale = 1;
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void ReloadLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
