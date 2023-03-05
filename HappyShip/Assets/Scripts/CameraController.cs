using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private GameObject targetObject; // the object to follow and look at
    private CinemachineVirtualCamera virtualCamera; // the Cinemachine virtual camera to control

    private void Start()
    {
        // find the Cinemachine virtual camera in the world
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        targetObject = FindObjectOfType<Movement>().gameObject;

        if (virtualCamera == null)
        {
            Debug.LogError("No Cinemachine virtual camera found in the scene!");
            return;
        }

        // set the virtual camera's follow and look at targets to the target object
        virtualCamera.Follow = targetObject.transform;
        virtualCamera.LookAt = targetObject.transform;
    }
    
}
