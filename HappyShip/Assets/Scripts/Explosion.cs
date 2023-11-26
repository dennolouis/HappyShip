using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float explosionRadius = 50f;
    public float explosionForce = 1000f;

    void Start()
    {
        // Visualize explosion radius in the scene view
        //DrawExplosionRadius();

        // Detect nearby objects with the "Player" tag
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            // Check if the object has the "Player" tag
            if (collider.CompareTag("Player"))
            {
                // Get the Rigidbody component from the player
                Rigidbody playerRigidbody = collider.GetComponent<Rigidbody>();

                if (playerRigidbody != null)
                {
                    // Calculate the force direction (opposite direction of the explosion)
                    Vector3 forceDirection = (playerRigidbody.transform.position - transform.position).normalized;

                    // Apply force to the player, scaled by Time.deltaTime
                    playerRigidbody.AddForce(forceDirection * explosionForce * Time.deltaTime, ForceMode.Impulse);
                }
            }
        }
    }

    //void DrawExplosionRadius()
    //{
    //    // Draw a wire sphere in the scene view to visualize the explosion radius
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, explosionRadius);
    //}
    //public float growthRate = 1.0f;  // Rate at which the sphere collider grows
    //private SphereCollider sphereCollider;

    //private void Start()
    //{
    //    // Get the SphereCollider component attached to the GameObject
    //    sphereCollider = GetComponent<SphereCollider>();

    //    if (sphereCollider == null)
    //    {
    //        Debug.LogError("SphereCollider component not found on the GameObject.");
    //    }
    //}

    //private void Update()
    //{
    //    // Increase the radius of the sphere collider over time
    //    float newRadius = sphereCollider.radius + growthRate * Time.deltaTime;
    //    sphereCollider.radius = newRadius;

    //    // Draw a wire sphere for visualization
    //    DebugDrawWireSphere(sphereCollider.transform.position, newRadius);
    //}

    //private void DebugDrawWireSphere(Vector3 center, float radius)
    //{
    //    // Draw a wire sphere in the scene view for visualization during testing
    //    Debug.DrawLine(center + new Vector3(radius, 0, 0), center + new Vector3(-radius, 0, 0), Color.red);
    //    Debug.DrawLine(center + new Vector3(0, radius, 0), center + new Vector3(0, -radius, 0), Color.green);
    //    Debug.DrawLine(center + new Vector3(0, 0, radius), center + new Vector3(0, 0, -radius), Color.blue);
    //}
}
