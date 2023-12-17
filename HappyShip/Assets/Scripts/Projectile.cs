using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    public void ShowHitEffect()
    {
        if (hitEffect)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ShowHitEffect();
        Destroy(gameObject, 0.5f);
    }
}
