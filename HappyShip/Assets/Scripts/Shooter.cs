using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float shootDelay = 1f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float aimAngle = 45f; // The auto-aim angle in degrees

    float timeSinceLastShot = 0f;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            // Perform a raycast sweep in the specified angle range
            for (float angle = -aimAngle; angle <= aimAngle; angle += 5f) // You can adjust the angle increment
            {
                Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
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
                        // Shoot the projectile
                        ShootProjectile(direction);
                        timeSinceLastShot = 0f;
                        break; // Stop the loop after the first valid target is found
                    }
                }
            }
        }
    }

    void ShootProjectile(Vector3 direction)
    {
        audioSource.Play();

        // Instantiate the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Add a rigidbody component to the projectile
        Rigidbody rb = projectile.AddComponent<Rigidbody>();

        // Apply a force to the projectile in the specified direction
        rb.velocity = direction * projectileSpeed;

        Destroy(projectile, 3f);
    }
}
