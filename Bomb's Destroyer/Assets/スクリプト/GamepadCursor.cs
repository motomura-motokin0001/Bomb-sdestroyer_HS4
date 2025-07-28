using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class GamepadCursor : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRectTransform;
    public InputActionAsset inputActions;
    public float cursorSpeed = 1000f;
    public RectTransform cursorRectTransform;
    private Vector2 moveInput;
    public InputActionReference selectAction;
    private InputActionMap playerMap;
    private InputActionMap uiMap;
    public PlayerInput _playerInput;


    private InputAction moveAction;

    void Start()
    {
        var actionMap = inputActions.FindActionMap("UIControl");
        moveAction = actionMap.FindAction("CursorMove");
        moveAction.Enable();
    }

    void Update()
    {
    moveInput = moveAction.ReadValue<Vector2>();

    Vector2 pos = cursorRectTransform.anchoredPosition;
    pos += moveInput * cursorSpeed * Time.unscaledDeltaTime;

    // Clamp処理（キャンバスサイズ）
    float width = canvasRectTransform.rect.width;
    float height = canvasRectTransform.rect.height;

    pos.x = Mathf.Clamp(pos.x, 0, width);
    pos.y = Mathf.Clamp(pos.y, 0, height);

    cursorRectTransform.anchoredPosition = pos;

        if (selectAction.action.WasPressedThisFrame())
        {
            Debug.Log("決定！");
            ClickUIUnderCursor();
        }
        if (_playerInput.actions["Menu"].triggered)
        {
            uiMap.Disable();
            playerMap.Enable();
        }
    }

    void ClickUIUnderCursor()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        data.position = RectTransformUtility.WorldToScreenPoint(null, cursorRectTransform.position);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);

        foreach (var result in results)
        {
            Button button = result.gameObject.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.Invoke();
                break;
            }
        }
    }
}
