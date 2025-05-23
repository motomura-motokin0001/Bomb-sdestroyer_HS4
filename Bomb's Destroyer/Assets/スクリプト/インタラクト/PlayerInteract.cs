using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f; // インタラクトできる距離
    public ResetButtonInteract ResetButtonInteract; // リセットボタンのインタラクトスクリプト
    public PlayerInput playerInput;

    private void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    void Update()
    {
        // 「E」キーが押された時にインタラクトを試みる
        if (playerInput.actions["Interact"].triggered)
        {
            Interact();
        }
    }

void Interact()
{
    Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;

    Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.green, 2f);

    if (Physics.Raycast(ray, out hit, interactDistance))
    {
        Debug.Log($"Rayが {hit.collider.gameObject.name} に当たりました！（タグ: {hit.collider.tag}）");

        switch (hit.collider.tag)
        {
            case "ResetButton_Tag":
                Debug.Log("リセットボタンが見つかりました！");
                ResetButtonInteract.Interact();
                break;
            default:
                Debug.Log("タグが一致しません！");
                break;
        }
    }
}
}