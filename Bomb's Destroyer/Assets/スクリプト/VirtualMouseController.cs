using UnityEngine;
using UnityEngine.InputSystem;

public class VirtualMouseController : MonoBehaviour
{
    [Header("Virtual Mouse Settings")]
    public GameObject virtualMouseCursor; // Virtual Mouseのカーソル用GameObject
    public float mouseSensitivity = 100f;
    public float gamepadSensitivity = 200f;
    
    private Vector2 gamepadInput;
    private Vector2 mouseInput;
    private Vector2 virtualMousePosition;
    private Camera mainCamera;
    
    // 入力の状態を追跡
    private bool isUsingGamepad = false;
    private float lastInputTime = 0f;
    private const float INPUT_SWITCH_DELAY = 0.1f; // 入力切り替えの遅延時間
    
    // 前フレームのマウス位置
    private Vector2 lastMousePosition;
    
    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
            mainCamera = FindObjectOfType<Camera>();
            
        // 初期状態は通常マウスカーソル表示
        SetMouseMode(false);
        
        // Virtual Mouseの初期位置を画面中央に設定
        virtualMousePosition = new Vector2(Screen.width / 2, Screen.height / 2);
        UpdateVirtualMousePosition();
        
        // 初期マウス位置を記録
        if (Mouse.current != null)
        {
            lastMousePosition = Mouse.current.position.ReadValue();
        }
    }
    
    void Update()
    {
        CheckForMouseInput();
        CheckForGamepadInput();
        
        if (isUsingGamepad)
        {
            UpdateVirtualMouse();
        }
    }
    
    void CheckForMouseInput()
    {
        // マウスが存在しない場合は処理をスキップ
        if (Mouse.current == null)
            return;
            
        try
        {
            // マウスの現在位置を取得
            Vector2 currentMousePosition = Mouse.current.position.ReadValue();
            
            // マウスの移動量を計算
            Vector2 mouseDelta = currentMousePosition - lastMousePosition;
            
            // マウスのクリックやスクロールもチェック
            bool hasMouseInput = mouseDelta.magnitude > 0.5f ||
                               Mouse.current.leftButton.isPressed ||
                               Mouse.current.rightButton.isPressed ||
                               Mouse.current.middleButton.isPressed ||
                               Mouse.current.scroll.ReadValue().magnitude > 0.1f;
            
            if (hasMouseInput && (isUsingGamepad || Time.time - lastInputTime > INPUT_SWITCH_DELAY))
            {
                SetMouseMode(false); // 通常マウスモードに切り替え
                lastInputTime = Time.time;
            }
            
            // マウス位置を更新
            lastMousePosition = currentMousePosition;
        }
        catch (System.Exception)
        {
            // マウス入力でエラーが発生した場合は無視
        }
    }
    
    void CheckForGamepadInput()
    {
        // ゲームパッドが存在しない場合は処理をスキップ
        if (Gamepad.current == null)
            return;
            
        try
        {
            // ゲームパッドの入力をチェック
            gamepadInput = Gamepad.current.leftStick.ReadValue();
            
            // ゲームパッドのボタン入力もチェック
            bool hasGamepadInput = gamepadInput.magnitude > 0.1f ||
                                 Gamepad.current.buttonSouth.isPressed ||
                                 Gamepad.current.buttonEast.isPressed ||
                                 Gamepad.current.buttonWest.isPressed ||
                                 Gamepad.current.buttonNorth.isPressed ||
                                 Gamepad.current.leftShoulder.isPressed ||
                                 Gamepad.current.rightShoulder.isPressed ||
                                 Gamepad.current.leftTrigger.ReadValue() > 0.1f ||
                                 Gamepad.current.rightTrigger.ReadValue() > 0.1f;
            
            if (hasGamepadInput && (!isUsingGamepad || Time.time - lastInputTime > INPUT_SWITCH_DELAY))
            {
                SetMouseMode(true); // Virtual Mouseモードに切り替え
                lastInputTime = Time.time;
            }
        }
        catch (System.Exception)
        {
            // ゲームパッド入力でエラーが発生した場合は無視
        }
    }
    
    void UpdateVirtualMouse()
    {
        // ゲームパッドの入力でVirtual Mouseの位置を更新
        Vector2 movement = gamepadInput * gamepadSensitivity * Time.deltaTime;
        virtualMousePosition += movement;
        
        // 画面外に出ないように制限
        virtualMousePosition.x = Mathf.Clamp(virtualMousePosition.x, 0, Screen.width);
        virtualMousePosition.y = Mathf.Clamp(virtualMousePosition.y, 0, Screen.height);
        
        UpdateVirtualMousePosition();
    }
    
    void UpdateVirtualMousePosition()
    {
        if (virtualMouseCursor != null && mainCamera != null)
        {
            // UIカンバスの場合
            Canvas canvas = virtualMouseCursor.GetComponentInParent<Canvas>();
            if (canvas != null && canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                // Screen Space Overlayの場合、直接スクリーン座標を使用
                virtualMouseCursor.transform.position = virtualMousePosition;
            }
            else
            {
                // ワールド座標に変換
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(virtualMousePosition.x, virtualMousePosition.y, mainCamera.nearClipPlane + 1f));
                virtualMouseCursor.transform.position = worldPosition;
            }
        }
    }
    
    void SetMouseMode(bool useVirtualMouse)
    {
        isUsingGamepad = useVirtualMouse;
        
        if (useVirtualMouse)
        {
            // Virtual Mouseモード
            Cursor.visible = false;
            if (virtualMouseCursor != null)
                virtualMouseCursor.SetActive(true);
        }
        else
        {
            // 通常マウスモード
            Cursor.visible = true;
            if (virtualMouseCursor != null)
                virtualMouseCursor.SetActive(false);
        }
    }
    
    // Virtual Mouseの位置を取得するパブリックメソッド
    public Vector2 GetVirtualMousePosition()
    {
        return virtualMousePosition;
    }
    
    // Virtual Mouseの位置を設定するパブリックメソッド
    public void SetVirtualMousePosition(Vector2 position)
    {
        virtualMousePosition = position;
        UpdateVirtualMousePosition();
    }
    
    // 現在のモードを取得
    public bool IsUsingGamepad()
    {
        return isUsingGamepad;
    }
    
    // デバッグ用の情報表示
    void OnGUI()
    {
        if (Application.isPlaying)
        {
            GUILayout.Label($"Input Mode: {(isUsingGamepad ? "Gamepad" : "Mouse")}");
            GUILayout.Label($"Virtual Mouse Position: {virtualMousePosition}");
            GUILayout.Label($"Gamepad Connected: {(Gamepad.current != null)}");
        }
    }
}