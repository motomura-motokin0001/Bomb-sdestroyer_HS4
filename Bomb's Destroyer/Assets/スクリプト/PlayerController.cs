using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 150f;
    public float lookSpeed = 2f;
    public Transform cameraTransform;
    public float jumpForce = 8f; // ジャンプ力
    public float gravity = 20f; // 重力
    public Vector3 respawnPosition = new Vector3(0f, 1f, 0f); // リスポーン位置

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float xRotation = 0f;
    private bool canJump = true;
    //public string frstSceneName;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // CharacterControllerがアタッチされているかチェックする
        if (controller == null)
        {
            Debug.LogError("CharacterController component is missing from this game object.");
        }

        // カーソルをロックする
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (controller != null)
        {
            if (controller.isGrounded)
            {
                // プレイヤーの移動
                float move = Input.GetAxis("Vertical") * speed;
                float strafe = Input.GetAxis("Horizontal") * speed;

                moveDirection = new Vector3(strafe, 0, move);
                moveDirection = transform.TransformDirection(moveDirection);

                // ジャンプ処理
                if (Input.GetButtonDown("Jump") && canJump)
                {
                    moveDirection.y = jumpForce;
                }

                if (Input.GetKeyDown("1"))
                {
                    SceneManager.LoadScene("square");
                }
                if (Input.GetKeyDown("2"))
                {
                    SceneManager.LoadScene("pyramid");
                }
                if (Input.GetKeyDown("3"))
                {
                    SceneManager.LoadScene("Board");
                }
            }

            // 重力の適用
            moveDirection.y -= gravity * Time.deltaTime;

            // 移動処理
            controller.Move(moveDirection * Time.deltaTime);

            // プレイヤーの回転（水平）
            float turn = Input.GetAxis("Mouse X") * lookSpeed;
            transform.Rotate(0, turn, 0);

            // カメラの回転（垂直）
            float look = Input.GetAxis("Mouse Y") * lookSpeed;
            xRotation -= look;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            // Y座標が-1以下になったらリスポーン
            if (transform.position.y < -1f)
            {
                RespawnPlayer();
            }
        }
    }

    void RespawnPlayer()
    {
        // プレイヤーをリスポーン位置に移動させる
        controller.enabled = false;
        transform.position = respawnPosition;
        controller.enabled = true;
    }
}
