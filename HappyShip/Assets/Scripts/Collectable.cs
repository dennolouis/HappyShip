using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject collectEffect;
    [SerializeField] float destroyEffectDuration = 1f;

    public void SpawnEffect()
    {
        if(collectEffect)
        {
            GameObject effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(effect, destroyEffectDuration);
        }

        Destroy(gameObject);
    }
}
