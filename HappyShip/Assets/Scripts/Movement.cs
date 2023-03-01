using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float thrustForce = 100;
    [SerializeField] float rotationSpeed = 1f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    void ApplyRotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
