using UnityEngine;

public class Wind : MonoBehaviour
{
    // Adjust this value to control the strength of the upward force
    [SerializeField] float force = 50f;

    //float y;

    //private void Start()
    //{
    //    y = GetComponent<Renderer>().material.mainTextureOffset.y;
    //}
    void Start()
    {
        // Get the MeshRenderer component attached to this GameObject
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        // Check if the MeshRenderer component exists
        if (meshRenderer != null)
        {
            // Disable the MeshRenderer component
            meshRenderer.enabled = false;
        }
        else
        {
            Debug.LogError("MeshRenderer component not found on this GameObject.");
        }
    }


    //private void Update()
    //{
    //    y += force / 40 * Time.deltaTime;
    //    GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, y));
    //}

    private void OnTriggerStay(Collider other)
    {
        // Check if the entering object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Get the Rigidbody component of the player
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            // Check if the Rigidbody component is not null
            if (playerRigidbody != null)
            {
                // Get the upward direction of the wind (Y direction of the GameObject)
                Vector3 windDirection = transform.up;

                // Apply an upward force to the player's Rigidbody in the wind direction
                playerRigidbody.AddForce(windDirection * force * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}
