using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;

    void GetHit()
    {
        health--;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Projectile")
    //    {
    //        Destroy(collision.gameObject);
    //        GetHit();
    //    }

    //}
}
