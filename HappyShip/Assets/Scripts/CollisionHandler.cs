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
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Player":
                Destroy(other.gameObject);
                player.UpdateLives(1);
                break;
            default:
                StartCrashSequence();
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.UpdateLives(1);
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
        else
        {
            FindObjectOfType<GameUI>().ShowContinueButton();
        }
    }

    void SpawnAtLastCheckPoint()
    {
        //gameObject.tag = "Friendly";
        FindObjectOfType<CheckPointSystem>().SpawnRocket();
        FindObjectOfType<CameraController>().LookAtRocket();
        Destroy(gameObject, 10);
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
    public void ReloadLevel()
    {
        Time.timeScale = 1;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void LoadNextLevel() //TODO Move to level changer
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
