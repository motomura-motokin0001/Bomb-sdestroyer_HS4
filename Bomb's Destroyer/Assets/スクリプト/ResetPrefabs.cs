using UnityEngine;

public class ResetPrefabs : MonoBehaviour
{
    public KeyCode resetKey = KeyCode.R; // リセットを行うキー
    public GameObject[] prefabsToReset; // リセットしたいプレハブの配列

    void Update()
    {
        // リセットキーが押されたら
        if (Input.GetKeyDown(resetKey))
        {
            // 全てのプレハブを削除
            foreach (GameObject prefab in prefabsToReset)
            {
                GameObject[] existingPrefabs = GameObject.FindGameObjectsWithTag(prefab.tag);
                foreach (GameObject obj in existingPrefabs)
                {
                    Destroy(obj);
                }

                // 同じ位置に再配置
                Vector3 spawnPosition = new Vector3(41f, 22f, 100f); // ここに再配置したい位置を設定する
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(prefab, spawnPosition, spawnRotation);
            }
        }
    }
}
