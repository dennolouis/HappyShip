using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{    
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    Player player;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //diable collsion while play testing
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(isTransitioning || collisionDisabled) return;

        switch(other.gameObject.tag)
        {
            case "Friendly":
                print("nice");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                print("fuel");
                break;
            default:
                StartCrashSequence();
                break;

        }
    }


    void StartCrashSequence()
    {
        isTransitioning = true;
        Destroy(GetComponent<Movement>());

        audioSource.Stop();
        audioSource.PlayOneShot(crash);

        crashParticle.Play();

        if(player.HasLife())
        {
            Invoke("SpawnAtLastCheckPoint", levelLoadDelay);
            player.UpdateLives(-1);
        }
    }

    void SpawnAtLastCheckPoint()
    {
        gameObject.tag = "Friendly";
        FindObjectOfType<CheckPointSystem>().SpawnRocket();
        FindObjectOfType<CameraController>().LookAtRocket();
        Destroy(gameObject, 3);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;

        audioSource.Stop();
        audioSource.PlayOneShot(success);

        successParticle.Play();

        Invoke("LoadNextLevel", levelLoadDelay);
    }
    void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentIndex + 1;
        if(nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }
        SceneManager.LoadScene(nextLevel);
    }
}
