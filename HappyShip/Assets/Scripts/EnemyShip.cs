using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    [SerializeField] float speed = 3;
    GameObject target;
    
    Oscillator oscillator;
    private void Start()
    {
        oscillator = GetComponent<Oscillator>();
    }
    void Update()
    {
        if(target)
        {
            transform.LookAt(target.transform);
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);

            RemoveOscillator();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.gameObject;
        }
    }

    void RemoveOscillator()
    {
        Destroy(oscillator);
    }
}
