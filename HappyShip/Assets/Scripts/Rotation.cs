using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] Vector3 rotationAxis = Vector3.up; // The axis around which the object will rotate
    [SerializeField] float rotationSpeed = 10f; // The speed at which the object will rotate

    // Update is called once per frame
    void Update () {
        // Rotate the object around the specified axis at the specified speed
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
