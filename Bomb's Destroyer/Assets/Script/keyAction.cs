using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Layouts;

public class keyAction : MonoBehaviour
{
    public GameObject PauseOJ;
    private bool isMenuVisible = false;
    public BombThrower bombThrower;
    // private InputActionMap playerMap;
    // private InputActionMap uiMap;
    public InputActionAsset inputActions;
    public static Mouse virtualMouse;
    private bool added;

    void Awake()
    {
        if (virtualMouse == null)
        {
            // 仮想マウスを追加
            virtualMouse = InputSystem.AddDevice<Mouse>("VirtualMouse");

            // 初期位置を設定（必要に応じて）
            InputSystem.QueueStateEvent(virtualMouse, new MouseState { position = new Vector2(Screen.width / 2f, Screen.height / 2f) });

            InputSystem.Update(); // 変更を反映
        }

        added = true;
    }




    void Start()
    {
        PauseOJ.SetActive(false);
        Time.timeScale = 1; // ゲーム開始時は通常速度
        // playerMap = inputActions.FindActionMap("Player");
        // uiMap = inputActions.FindActionMap("UIControl");
        
    }

    void Update()
    {
        if (bombThrower._playerInput.actions["Menu"].triggered)
        {
            // playerMap.Disable();
            // uiMap.Enable();
            isMenuVisible = !isMenuVisible;
            bombThrower.canThrowBomb = !isMenuVisible;

            // ゲームの一時停止 or 再開
            Time.timeScale = isMenuVisible ? 0 : 1;

            // メニューの表示・非表示
            
                PauseOJ.SetActive(isMenuVisible);

                Debug.Log("Escが押されました");
        }
    }

    public void OnClickResumeButton()
    {
        isMenuVisible = false;
        bombThrower.canThrowBomb = true;

        // ゲームの再開
        Time.timeScale = 1;


        // メニューの非表示
        PauseOJ.SetActive(false);
    }
}
