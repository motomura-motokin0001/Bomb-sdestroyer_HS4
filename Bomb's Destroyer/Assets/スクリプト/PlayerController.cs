using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public GameObject PlayerObject;
    public float speed = 20f;
    public float turnSpeed = 150f;
    public float lookSpeed = 2f;
    public Transform cameraTransform;
    public float jumpForce = 8f; // ジャンプ力

    public Vector3 respawnPosition = new Vector3(0f, 1f, 0f); // リスポーン位置

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float xRotation = 0f;
    [SerializeField] private bool canJump = true;
    public bool lockCursor = true; // マウスカーソルをロックするかどうか

    public Transform playerBody;
    private Rigidbody rb;
    public float moveSpeed = 10f;
    public float maxSpeed = 5f;
    public float mouseSensitivity = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;

        UpdateCursorState();
    }

    // test
    Vector3 currentAngle = new Vector3();

    void Update()
    {

        if (Time.timeScale == 0)
        {
            return; // ゲームが一時停止中なら何もしない
        }
        float t = Time.deltaTime;

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        //Vector3 move = new Vector3(moveX, 0, moveZ).normalized;
        var cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 addForce = new Vector3(moveX, 0, moveZ).normalized * t * moveSpeed;
        if (Input.GetButtonDown("Jump") && canJump && gameObject.tag != null)
            addForce.y = jumpForce;
        /*Vector3 horizontalVelocity = new Vector3 (rb.velocity.x, 0, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            rb.velocity = new Vector3(horizontalVelocity.normalized.x * maxSpeed, rb.velocity.y, horizontalVelocity.normalized.z * maxSpeed);
        }*/

        // 速度上限を超えない
        var tmp = rb.velocity;
        tmp.x = Mathf.Min(tmp.x, maxSpeed);
        tmp.y = Mathf.Min(tmp.y, maxSpeed);
        tmp.z = Mathf.Min(tmp.z, maxSpeed);
        rb.velocity = tmp;
        rb.AddForce(addForce, ForceMode.Acceleration);

        /*
        // プレイヤーの回転（水平）
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // カメラの回転（垂直）
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * mouseX);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        */

        // test
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");

        Vector3 v = new Vector3();
        v.x = mY * mouseSensitivity * t * -1;
        v.y = mX * mouseSensitivity * t;

        currentAngle += v;

        _camera.transform.rotation = Quaternion.Euler(currentAngle);
        PlayerObject.transform.rotation = _camera.transform.rotation ;

    }


    public void SetCursorLock(bool state)
    {
        lockCursor = state;
        UpdateCursorState();
    }

    private void UpdateCursorState()
    {
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }
}
