using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float growthRate = 1.0f;  // Rate at which the sphere collider grows
    private SphereCollider sphereCollider;

    private void Start()
    {
        // Get the SphereCollider component attached to the GameObject
        sphereCollider = GetComponent<SphereCollider>();

        if (sphereCollider == null)
        {
            Debug.LogError("SphereCollider component not found on the GameObject.");
        }
    }

    private void Update()
    {
        // Increase the radius of the sphere collider over time
        float newRadius = sphereCollider.radius + growthRate * Time.deltaTime;
        sphereCollider.radius = newRadius;

        // Draw a wire sphere for visualization
        DebugDrawWireSphere(sphereCollider.transform.position, newRadius);
    }

    private void DebugDrawWireSphere(Vector3 center, float radius)
    {
        // Draw a wire sphere in the scene view for visualization during testing
        Debug.DrawLine(center + new Vector3(radius, 0, 0), center + new Vector3(-radius, 0, 0), Color.red);
        Debug.DrawLine(center + new Vector3(0, radius, 0), center + new Vector3(0, -radius, 0), Color.green);
        Debug.DrawLine(center + new Vector3(0, 0, radius), center + new Vector3(0, 0, -radius), Color.blue);
    }
}
