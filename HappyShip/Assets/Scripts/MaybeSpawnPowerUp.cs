using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaybeSpawnPowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUp;
    [SerializeField] GameObject coin;
    // Start is called before the first frame update
    void Start()
    {

        GameObject objToSpawn = Random.Range(0, 10) > 7? powerUp: coin;

        if (objToSpawn)
        {
            Vector3 pos = transform.position;
            pos.z = 0;
            GameObject spawnedPowerUp = Instantiate(objToSpawn, pos, Quaternion.identity);
            Destroy(spawnedPowerUp, 10f);
        }
        
    }
}
