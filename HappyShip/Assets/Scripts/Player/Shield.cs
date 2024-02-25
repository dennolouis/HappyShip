using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] GameObject destoryEffect;
    [SerializeField] float destroyEffectDuration = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        Health enemyHealth = other.gameObject.GetComponent<Health>();
        if (enemyHealth)
        {
            enemyHealth.ShowDestroyEffect();
            ShowDestroyEffect();
        }
    }

    public void ShowDestroyEffect()
    {
        if (destoryEffect)
        {
            GameObject effect = Instantiate(destoryEffect, transform.position, Quaternion.identity);
            Destroy(effect, destroyEffectDuration);
        }

        Destroy(gameObject);
    }
}
