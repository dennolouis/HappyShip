using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnySpawn : MonoBehaviour
{
    [SerializeField] GameObject bunnyPrefab;

    [SerializeField] Vector3 spawnDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Create a rotation that represents a 90-degree rotation around the y-axis.
            Quaternion rotation = Quaternion.Euler(spawnDirection);

            // Instantiate the bunny object with the specified rotation.
            GameObject bunny = Instantiate(bunnyPrefab, transform.position, rotation);

            bunny.transform.localScale += new Vector3(2, 2, 2);


            Animator anim = bunny.GetComponent<Animator>();

            anim.SetInteger("AnimIndex", 1);
            anim.SetTrigger("Next");


            Destroy(bunny, 10f);

        }
    }
}
