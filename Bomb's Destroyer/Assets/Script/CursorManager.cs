using UnityEngine;
using UnityEngine.InputSystem;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private GameObject virtualCursor;
    [SerializeField] private GameObject realCursor;

    private RectTransform virtualCursorRect;
    private string currentDevice = "Mouse";

    void Start()
    {
        SetCursorMode("Mouse");

        if (virtualCursor != null)
            virtualCursorRect = virtualCursor.GetComponent<RectTransform>();
    }

    void Update()
    {
        bool mouseMoved = Mouse.current != null && Mouse.current.delta.ReadValue().sqrMagnitude > 0.01f;
        bool mouseClicked = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        bool gamepadMoved = Gamepad.current != null &&
            (Gamepad.current.leftStick.ReadValue().sqrMagnitude > 0.1f ||
             Gamepad.current.rightStick.ReadValue().sqrMagnitude > 0.1f);

        bool gamepadPressed = Gamepad.current != null &&
            (Gamepad.current.aButton.wasPressedThisFrame ||
             Gamepad.current.dpad.ReadValue().sqrMagnitude > 0.1f);

        if ((mouseMoved || mouseClicked) && currentDevice != "Mouse")
        {
            SetCursorMode("Mouse");
        }
        else if ((gamepadMoved || gamepadPressed) && currentDevice != "Gamepad")
        {
            SetCursorMode("Gamepad");
        }
    }

    private void SetCursorMode(string device)
    {
        currentDevice = device;

        if (device == "Mouse")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (virtualCursor != null) virtualCursor.SetActive(false);
            if (realCursor != null) realCursor.SetActive(true);

            // ✅ 仮想カーソルの位置だけ中央に戻す（見えなくても）
            if (virtualCursorRect != null)
                virtualCursorRect.anchoredPosition = Vector2.zero;
        }
        else if (device == "Gamepad")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // ✅ 仮想カーソルを中央に戻してから表示する
            if (virtualCursorRect != null)
                virtualCursorRect.anchoredPosition = Vector2.zero;

            if (virtualCursor != null) virtualCursor.SetActive(true);
            if (realCursor != null) realCursor.SetActive(false);
        }
    }

}
