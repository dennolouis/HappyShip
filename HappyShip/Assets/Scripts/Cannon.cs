using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float ballSpeed = 10f;
    [SerializeField] float shootInterval = 3f;
    float timeSinceLastShot = 0f;
    GameObject target;
    bool inRange = false;
    void Update()
    {
        if(inRange && target)
        {
            transform.LookAt(target.transform);
            HandleShooting();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, transform.rotation);
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        ballRb.AddForce(transform.forward * ballSpeed, ForceMode.Impulse);

        Destroy(ball, 7f);
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
