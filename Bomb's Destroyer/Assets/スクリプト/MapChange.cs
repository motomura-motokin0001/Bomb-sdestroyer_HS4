using UnityEngine;
using UnityEngine.InputSystem;
public enum InputMode
{
    Player,
    UIControl
}
public class MapChange : MonoBehaviour
{
public InputActionAsset inputActions;

    [SerializeField] private InputMode inputMode = InputMode.Player;
    private InputActionMap playerMap;
    private InputActionMap uiMap;

    void Start()
    {
        playerMap = inputActions.FindActionMap("Player");
        uiMap = inputActions.FindActionMap("UIControl");

        switch (inputMode)
        {
            case InputMode.Player:
                playerMap.Enable();  // デフォルトでプレイヤー操作
                uiMap.Disable();
                break;
            case InputMode.UIControl:
                playerMap.Disable();
                uiMap.Enable();  // デフォルトでUI操作
                break;
        }
    }

    public void SwitchToUI()
    {
        playerMap.Disable();
        uiMap.Enable();
        Debug.Log("UIControlに切り替えました");
    }

    public void SwitchToPlayer()
    {
        uiMap.Disable();
        playerMap.Enable();
        Debug.Log("Playerに切り替えました");
    }
}