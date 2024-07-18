using UnityEngine;

public class BombThrower : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombSpawnPoint;
    public float throwForce = 10f; // 初速度の調整用
    public Camera playerCamera; // プレイヤーカメラ

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowBomb();
        }
    }

    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();

        // カメラの前方向に投げる
        Vector3 throwDirection = playerCamera.transform.forward;
        rb.AddForce(throwDirection * throwForce, ForceMode.VelocityChange);
    }
}
