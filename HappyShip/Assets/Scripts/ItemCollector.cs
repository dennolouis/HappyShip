using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    float magnetRange = 5f;
    float magnetForce = 25000f;

    private void Update()
    {
        // Detect nearby coins
        Collider[] nearbyCoins = Physics.OverlapSphere(transform.position, magnetRange, LayerMask.GetMask("Collectable"));

        // Apply magnet effect to nearby coins
        foreach (Collider coinCollider in nearbyCoins)
        {
            Vector3 magnetDirection = transform.position - coinCollider.transform.position;
            coinCollider.GetComponent<Rigidbody>().AddForce(magnetDirection.normalized * magnetForce * Time.deltaTime);
        }
    }
}