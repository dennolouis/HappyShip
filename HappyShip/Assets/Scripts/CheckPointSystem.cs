using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    [SerializeField] Transform activeCheckPoint;
    GameObject rocket;

    Player player;

    MovementController movementContoller;

    void Start()
    {
        player = FindObjectOfType<Player>();
        movementContoller = FindObjectOfType<MovementController>();

        string rocketPrefabName = player.GetRocketIndex().ToString();

        SetRocket(rocketPrefabName);

        SpawnRocket();
    }

    public void SpawnRocket()
    {
        GameObject playerRocket = Instantiate(rocket, activeCheckPoint.position, activeCheckPoint.rotation);
        movementContoller.SetMovement(playerRocket.GetComponent<Movement>());
    }

    public void SetCheckPoint(Transform checkPoint)
    {
        activeCheckPoint = checkPoint;
    }

    void SetRocket(string prefabName)
    {
        // Specify the path to the folder where the prefabs are stored
        string folderPath = "Prefabs/Rockets/";

        // Combine the folder path and prefab name to get the full path
        string prefabPath = Path.Combine(folderPath, prefabName);

        // Load the prefab as a GameObject
        rocket = Resources.Load<GameObject>(prefabPath);

        if (rocket == null)
        {
            Debug.LogError("Rocket not found: " + prefabPath);
        }
        else
        {
            Debug.Log("Rocket loaded: " + prefabPath);
        }
    }

}
