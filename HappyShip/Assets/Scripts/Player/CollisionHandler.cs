using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] float respawnImmunityDuration = 3f; // Duration of immunity after respawn
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    Player player;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;
    bool justRespawned = true;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(DisableRespawnCollisionImmunity());
    }

    private void Update()
    {
        // Disable collision while play testing
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled || (justRespawned && ShouldIgnoreCollisionWithHealth(other.gameObject)))
            return;

        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Player":
            case "Projectile":
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
        if (isTransitioning || collisionDisabled || (justRespawned && ShouldIgnoreCollisionWithHealth(other.gameObject)))
            return;

        Collectable collectable = other.gameObject.GetComponent<Collectable>();

        switch (other.gameObject.tag)
        {
            case "Player":
                player.UpdateLives(1);
                Destroy(other.gameObject);
                break;

            case "Heart":
                player.UpdateLives(1);
                if (collectable) { collectable.SpawnEffect(); }
                else { Destroy(other.gameObject); }
                break;

            case "Star":
                player.CollectStar();
                if (collectable) { collectable.SpawnEffect(); }
                else { Destroy(other.gameObject); }
                break;

            case "Coin":
                player.CollectCoin();
                if (player.GetRocketIndex() == 0) player.CollectCoin(); //collects double coins
                Destroy(other.gameObject);
                break;

            case "Friendly":
                return;

            case "Enemy":
                return;

            case "BulletPowerUp":
                HandleBulletPowerUp(other.gameObject);
                if (collectable) { collectable.SpawnEffect(); }
                else { Destroy(other.gameObject); }
                break;
        }
    }


    private bool ShouldIgnoreCollisionWithHealth(GameObject otherGameObject)
    {
        Health healthScript = otherGameObject.GetComponent<Health>();
        return healthScript != null;
    }

    public void StartCrashSequence()
    {
        isTransitioning = true;
        Destroy(GetComponent<Movement>());
        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<ItemCollector>());

        audioSource.Stop();
        audioSource.PlayOneShot(crash);

        crashParticle.Play();

        if (player.HasLife())
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

    IEnumerator DisableRespawnCollisionImmunity()
    {
        yield return new WaitForSeconds(respawnImmunityDuration);
        justRespawned = false; // Disable respawn immunity after specified duration
    }

    void StartSuccessSequence()
    {
        player.Save();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;

        audioSource.Stop();
        audioSource.PlayOneShot(success);

        successParticle.Play();

        Invoke("GoHome", levelLoadDelay);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void GoHome()
    {
        FindObjectOfType<LevelChanger>().GoHome();
    }

    IEnumerator ResetAmmoAfterDelay(Shooter shooter)
    {
        yield return new WaitForSeconds(10f); // Reset ammo after 10 seconds
        shooter.ResetAmmo();
    }

    private void HandleBulletPowerUp(GameObject powerUpObject)
    {
        Shooter shooter = GetComponentInChildren<Shooter>();
        if (shooter != null)
        {
            shooter.ModifyAmmo(1); // Increase ammo count by 1
            StartCoroutine(ResetAmmoAfterDelay(shooter));
            Destroy(powerUpObject);
        }
    }

}
