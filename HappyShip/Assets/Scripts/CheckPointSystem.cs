using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    [SerializeField] Transform activeCheckPoint;
    [SerializeField] GameObject rocket;
    void Start()
    {
        SpawnRocket();
    }
    public void SpawnRocket()
    {
        Instantiate(rocket, activeCheckPoint.position, activeCheckPoint.rotation);
    }

    public void SetCheckPoint(Transform checkPoint)
    {
        activeCheckPoint = checkPoint;
    }
}
