using UnityEngine;
using TMPro;

public class ObjectCount : MonoBehaviour
{
    public string targetTag = "TargetObject";  // タグ名
    public TextMeshProUGUI countText;  // 結果を表示するTextMeshPro

    void Update()
    {
        // タグを持つすべてのオブジェクトを取得
        GameObject[] R_objects = GameObject.FindGameObjectsWithTag(targetTag);

        int count = 0;

        foreach (GameObject obj in R_objects)
        {
            // 親オブジェクトが targetTag を持っている場合、その子オブジェクトをカウント
            if (obj.transform.parent != null && obj.transform.parent.CompareTag(targetTag))
            {
                // 親オブジェクトが targetTag を持っている場合、子オブジェクトはカウント
                count++;
            }
            else if (obj.transform.parent == null)
            {
                // 親オブジェクトがない場合（親なしのオブジェクト）はそのままカウント
                count++;
            }
        }
            count -= 1;
        // オブジェクトの数を表示
        countText.text = "オブジェクトの数:      " + count.ToString();
        Debug.Log("現在のオブジェクト数: " + count);
    }
}
