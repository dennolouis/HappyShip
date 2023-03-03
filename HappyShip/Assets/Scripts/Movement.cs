using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float thrustForce = 100;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] AudioClip engineThrust;

    [SerializeField] ParticleSystem engineThrustParticles;
   
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Thrust();
        }
        else
        {
            StopThrust();
        }

        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void StopThrust()
    {
        audioSource.Stop();
        engineThrustParticles.Stop();
    }

    private void Thrust()
    {
        rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);

        if (!engineThrustParticles.isPlaying)
        {
            engineThrustParticles.Play();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineThrust);
        }
    }

    void ApplyRotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
