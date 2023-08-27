using UnityEngine;

public class AstronautPlayer : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 5f;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
            Vector3 directionToTarget = target.transform.position - transform.position;
            directionToTarget.y = 0f; // Ignore the Y difference for rotation on the Y-axis

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            anim.SetInteger("AnimationPar", 1);
        }

        //print(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }
}
