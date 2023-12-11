using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] GameObject missilePrefab;
    [SerializeField] List<Transform > spawnPoints;
    [SerializeField] float ballSpeed = 10f;
    [SerializeField] float shootInterval = 3f;
    float timeSinceLastShot = 0f;
    GameObject target;
    bool inRange = false;
    void Update()
    {
        if (inRange && target)
        {
            //transform.LookAt(target.transform);
            HandleShooting();
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
        foreach(Transform spawnPoint in spawnPoints)
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
}
