using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float shootDelay = 1f;
    [SerializeField] float projectileSpeed = 10f;
    
    float timeSinceLastShot = 0f;
    
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
            // Cast a ray from this gameObject's position
            Ray ray = new Ray(transform.position, transform.forward);

            // Check if the ray hits a gameObject with a Health script attached
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Health healthScript = hitInfo.collider.gameObject.GetComponent<Health>();
                if (healthScript != null)
                {
                    // Shoot the projectile
                    ShootProjectile();
                    timeSinceLastShot = 0f;
                }
            }
        }
    }

    void ShootProjectile()
    {
        // Instantiate the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Add a rigidbody component to the projectile
        Rigidbody rb = projectile.AddComponent<Rigidbody>();

        // Apply a force to the projectile's z-axis relative to its transform
        rb.AddRelativeForce(Vector3.forward * projectileSpeed, ForceMode.VelocityChange);

        Destroy(projectile, 3f);
    }
}
