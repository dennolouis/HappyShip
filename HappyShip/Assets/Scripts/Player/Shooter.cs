using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject muzzle;
    [SerializeField] float muzzleDuration = 0.25f;
    [SerializeField] float shootDelay = 1f;
    [SerializeField] float projectileSpeed = 60f;
    [SerializeField] float aimAngle = 30f; // The auto-aim angle in degrees

    float timeSinceLastShot = 0f;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (muzzle)
        {
            muzzle.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to shoot again
        if (timeSinceLastShot < shootDelay)
        {
            timeSinceLastShot += Time.deltaTime;
        }
        else
        {
            StartCoroutine(ShootProjectilesWithDelay());
            timeSinceLastShot = 0f;
        }
    }

    IEnumerator ShootProjectilesWithDelay()
    {
        for (int i = 0; i < 3; i++)
        {
            ShootProjectile();
            yield return new WaitForSeconds(0.05f); // Adjust the delay between shots
        }

        //timeSinceLastShot = 0f; // Reset the timer after shooting three projectiles
    }

    void ShootProjectile()
    {
        audioSource.Play();

        // Instantiate the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Add a rigidbody component to the projectile
        Rigidbody rb = projectile.AddComponent<Rigidbody>();

        // Apply a force to the projectile in the forward direction
        rb.velocity = transform.forward * projectileSpeed;

        Destroy(projectile, 3f);

        // Check if a muzzle GameObject is set
        if (muzzle != null)
        {
            // Enable the muzzle GameObject
            muzzle.SetActive(true);

            // Disable the muzzle after a specified duration
            StartCoroutine(DisableMuzzleAfterDelay());
        }
    }

    IEnumerator DisableMuzzleAfterDelay()
    {
        yield return new WaitForSeconds(muzzleDuration);

        // Check if a muzzle GameObject is set
        if (muzzle != null)
        {
            // Disable the muzzle GameObject
            muzzle.SetActive(false);
        }
    }
}
