using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;

    [SerializeField] GameObject destoryEffect;
    [SerializeField] float destroyEffectDuration = 1f;

    void GetHit()
    {
        health--;

        if(health <= 0)
        {
            ShowDestoryEffect();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            GetHit();
            collision.gameObject.GetComponent<Projectile>().ShowHitEffect();
            Destroy(collision.gameObject);
        }
    }

    void ShowDestoryEffect()
    {
        if(destoryEffect)
        {
            GameObject effect = Instantiate(destoryEffect, transform.position, Quaternion.identity);
            Destroy(effect, destroyEffectDuration);
        }

    }

}
