using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 150f;
    public float lookSpeed = 2f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float xRotation = 0f;

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
            // プレイヤーの移動
            float move = Input.GetAxis("Vertical") * speed;
            float strafe = Input.GetAxis("Horizontal") * speed;

            moveDirection = new Vector3(strafe, 0, move);
            moveDirection = transform.TransformDirection(moveDirection);
            controller.Move(moveDirection * Time.deltaTime);

            // プレイヤーの回転（水平）
            float turn = Input.GetAxis("Mouse X") * lookSpeed;
            transform.Rotate(0, turn, 0);

            // カメラの回転（垂直）
            float look = Input.GetAxis("Mouse Y") * lookSpeed;
            xRotation -= look;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
    }
}
