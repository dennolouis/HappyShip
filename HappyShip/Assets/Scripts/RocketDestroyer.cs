using System.Collections;
using UnityEngine;

public class RocketDestroyer : MonoBehaviour
{
    [SerializeField] private float forceAmount = 20f;
    [SerializeField] private float delayBeforeForce = 2f;
    [SerializeField] private float delayBetweenForces = 5f;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ApplyForceWithDelay());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }

    private IEnumerator ApplyForceWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeForce);

        PlayThrustSound();

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 localForce = transform.forward * forceAmount;
            rb.AddForce(localForce, ForceMode.Impulse);
        }

        yield return new WaitForSeconds(delayBetweenForces);

        // Apply the force again after the delayBetweenForces
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 localForce = transform.forward * forceAmount;
            rb.AddForce(localForce, ForceMode.Impulse);
        }
    }

    void PlayThrustSound()
    {
        if(audioSource)
            audioSource.Play();

    }
}



