using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] GameObject missilePrefab;
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] float ballSpeed = 10f;
    [SerializeField] float shootInterval = 3f;
    [SerializeField] GameObject effect;
    float timeSinceLastShot = 0f;
    GameObject target;
    bool inRange = false;
    bool effectActive = false;

    void Update()
    {
        if (inRange && target)
        {
            HandleShooting();
        }

        if (effectActive)
        {
            // Check if 'effect' is not null before attempting to access its properties
            if (effect != null)
            {
                StartCoroutine(DeactivateEffectAfterDelay(1.2f));
            }
            else
            {
                Debug.LogWarning("Effect is null.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    void Shoot()
    {
        effect.SetActive(true);
        effectActive = true;

        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject missile = Instantiate(missilePrefab, spawnPoint.position, transform.rotation);
            Rigidbody missileRb = missile.GetComponent<Rigidbody>();
            missileRb.AddForce(spawnPoint.forward * ballSpeed, ForceMode.Impulse);

            Destroy(missile, 7f);
        }
    }

    void HandleShooting()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    IEnumerator DeactivateEffectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Check if 'effect' is not null before attempting to access its properties
        if (effect != null)
        {
            effect.SetActive(false);
            effectActive = false;
        }
        else
        {
            Debug.LogWarning("Effect is null.");
        }
    }
}
