using UnityEngine;
using UnityEngine.InputSystem;

public class BombThrower : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombSpawnPoint;
    public float throwForce = 10f; // 初速度の調整用
    public Camera playerCamera; // プレイヤーカメラ
    public bool canThrowBomb = true; // 爆弾を投げられるかどうか
    public PlayerInput _playerInput;


    void Update()
    {
        if (canThrowBomb)
        {
            if (_playerInput.actions["Throw"].triggered)
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
        //DataManager.Instance.Throw++;
        
        }
    }
}