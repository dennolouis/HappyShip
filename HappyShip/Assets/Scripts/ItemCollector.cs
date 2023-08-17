using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public float magnetRange = 5f;
    public float magnetForce = 15f;

    private void Update()
    {
        // Detect nearby coins
        Collider[] nearbyCoins = Physics.OverlapSphere(transform.position, magnetRange, LayerMask.GetMask("Collectable"));

        // Apply magnet effect to nearby coins
        foreach (Collider coinCollider in nearbyCoins)
        {
            Vector3 magnetDirection = transform.position - coinCollider.transform.position;
            coinCollider.GetComponent<Rigidbody>().AddForce(magnetDirection.normalized * magnetForce);
        }
    }
}