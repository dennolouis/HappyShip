using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("PlayerInRange");
            target = other.gameObject;
        }
    }

    private void Update()
    {
        if (target)
        {
            float yDifference = Mathf.Abs(target.transform.position.y - transform.position.y);

            if (yDifference < 2f)
            {
                transform.LookAt(target.transform);
            }
        }
    }
}
