using Unity.VisualScripting;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float explosionForce = 700f;
    public float explosionRadius = 5f;
    public float explosionDelay = 0f; // 爆発までの遅延時間
    public float destroyYThreshold = 0f; // 破壊されるY座標の閾値
    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ

    private bool isStuck = false;

    void Update()
    {
        // Y座標が0以下になったら破壊する
        if (transform.position.y <= destroyYThreshold)
        {
            Destroy(gameObject);
        }
    }

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
        // Rigidbody rb = GetComponent<Rigidbody>();
        // rb.isKinematic = true;
        transform.SetParent(collision.transform);
        
        // 一定時間後に爆発
        Invoke("Explode", explosionDelay);
        
    }

    void Explode()
    {
        // 爆発エフェクトの生成
        if (explosionPrefab != null)
        {
            Vector3 spawnPosition = transform.position + new Vector3 (0,1,0);
            GameObject effect = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
            Destroy(effect, 3f);
        }

        // 爆発範囲内のオブジェクトに爆風を適用
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // ボムの破壊
        Destroy(gameObject);
        
    }
}
