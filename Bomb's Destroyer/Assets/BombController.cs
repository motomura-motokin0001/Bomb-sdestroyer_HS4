using UnityEngine;

public class BombController : MonoBehaviour
{
    public float explosionForce = 700f;
    public float explosionRadius = 5f;
    public float explosionDelay = 3f; // 爆発までの遅延時間

    private bool isStuck = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.tag == "Block")
        {
            StickToBlock(collision);
        }
    }

    void StickToBlock(Collision collision)
    {
        // ボムをブロックに引っ付ける
        isStuck = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        transform.SetParent(collision.transform);
        
        // 一定時間後に爆発
        Invoke("Explode", explosionDelay);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Destroy(gameObject);
    }
}