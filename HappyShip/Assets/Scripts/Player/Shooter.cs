using System.Collections;
using System.Collections.Generic;
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

        if(muzzle)
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
            RayCastShooting();
        }
    }

    IEnumerator ShootProjectile(Vector3 direction)
    {
        audioSource.Play();

        for (int i = 0; i < 3; i++)
        {
            // Instantiate the projectile prefab
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Add a rigidbody component to the projectile
            Rigidbody rb = projectile.AddComponent<Rigidbody>();

            // Apply a force to the projectile in the specified direction
            rb.velocity = direction * projectileSpeed;

            Destroy(projectile, 3f);
            yield return new WaitForSeconds(0.05f); // Adjust the delay between shots
        }

        

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

    void RayCastShooting()
    {
        // Perform a raycast sweep in the specified angle range
        for (float angle = -aimAngle; angle <= aimAngle; angle += 5f) // You can adjust the angle increment
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            Vector3 direction = rotation * transform.forward;

            // Cast a ray from this gameObject's position
            Ray ray = new Ray(transform.position, direction);

            // Check if the ray hits a gameObject with a Health script attached
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Health healthScript = hitInfo.collider.gameObject.GetComponent<Health>();
                if (healthScript != null)
                {
                    // Visualize the raycast
                    Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red, 0.1f);
                    print("hii");

                    // Shoot the projectile
                    StartCoroutine(ShootProjectile(direction));
                    timeSinceLastShot = 0f;
                    break; // Stop the loop after the first valid target is found
                }
            }
            else
            {
                // Visualize the raycast
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green, 0.1f);
            }
        }
    }

}
