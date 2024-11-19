using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f; // インタラクトできる距離
    private GameObject currentInteractable; // インタラクト可能なオブジェクト

    void Update()
    {
        // 「E」キーが押された時にインタラクトを試みる
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

void Interact()
{
    // プレイヤーの前方にRayを飛ばしてインタラクト可能なオブジェクトをチェック
    Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;

    Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.green, 2f);

    if (Physics.Raycast(ray, out hit, interactDistance))
    {
        if (hit.collider.CompareTag("Interactable"))
        {
            currentInteractable = hit.collider.gameObject;
            Debug.Log($"ヒットしたオブジェクト: {currentInteractable.name}");

            // オブジェクトのインタラクトロジックを呼び出す
            var interactableComponent = currentInteractable.GetComponent<IInteractable>();
            if (interactableComponent != null)
            {
                interactableComponent.Interact();
            }
            else
            {
                Debug.LogError("IInteractableが見つかりませんでした。");
            }
        }
    }
}

}
