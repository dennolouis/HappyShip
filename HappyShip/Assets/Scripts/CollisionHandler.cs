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
            case "Player":
                Destroy(other.gameObject);
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
                player.UpdateLives(1);
                break;

            case "Heart":
                player.UpdateLives(1);
                break;

            case "Star":
                //TODO: Star logic stuff
                break;

            case "Coin":
                //TODO: Coin logic stuff
                break;
        }

        if (!other.gameObject.GetComponent<CheckPoint>()) //does not destroy checkpoints
            Destroy(other.gameObject);
    }


    public void StartCrashSequence()
    {
        isTransitioning = true;
        Destroy(GetComponent<Movement>());
        Destroy(GetComponent<Collider>());

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

    public void SpawnAtLastCheckPoint()
    {
        gameObject.tag = "Friendly";
        isTransitioning = true;
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
