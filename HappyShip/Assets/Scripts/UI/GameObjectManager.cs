using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects;

    void Start()
    {
        // Assuming you want to hide all GameObjects at the start
        //HideAllGameObjects();
    }

    public void ShowGameObject(GameObject objectToShow)
    {
        // Hide all other GameObjects
        foreach (GameObject go in gameObjects)
        {
            if (go != objectToShow)
            {
                go.SetActive(false);
            }
        }

        // Show the specified GameObject
        objectToShow.SetActive(true);
    }

    public void HideAllGameObjects()
    {
        // Hide all GameObjects
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
    }
}
