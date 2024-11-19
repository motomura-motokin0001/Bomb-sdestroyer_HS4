using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Reflection;
using Unity.VisualScripting;

public class inputDeta : MonoBehaviour
{
    public TextMeshProUGUI itemtext;
    public string itemname;



    void Update()
    {
        // DataManagerのType情報を取得
        System.Type dataType = typeof(DataManager);
        
        // 指定されたitemnameに対応するフィールドを取得
        FieldInfo field = dataType.GetField(itemname);

        // フィールドが存在するかチェック
        if (field != null)
        {
            // フィールドの値を取得して文字列に変換
            object value = field.GetValue(DataManager.Instance);
            itemtext.text = value.ToString();
        }
        else
        {
            Debug.Log($"DataManagerには'{itemname}'というフィールドがありません。");
        }
    }
}
