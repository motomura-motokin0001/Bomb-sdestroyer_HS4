using UnityEngine;
using UnityEngine.InputSystem;

public class SkyBoxManager : MonoBehaviour
{
    [Range(0.001f, 1.0f)]
    public float rotateSpeed;

    public Material[] Sky_Box_List;
    private int num = 0;

    public Camera Camera;

    public InputActionReference changeActionRef; // ← これがInputActionReference

    void Start()
    {
        var _RandomNumber = Random.Range(0, Sky_Box_List.Length);
        RenderSettings.skybox = Sky_Box_List[_RandomNumber];
    }
    void OnEnable()
    {
        changeActionRef.action.Enable(); // 有効化が必要
    }

    void OnDisable()
    {
        changeActionRef.action.Disable(); // 無効化も忘れずに
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Rotation();
        Change();
    }

    void Change()
    {
        if (changeActionRef.action.triggered) // ← triggeredを使う
        {
            Debug.Log("Change SkyBox");
            num++;

            if (num >= Sky_Box_List.Length)
                num = 0;

            RenderSettings.skybox = Sky_Box_List[num];
        }
    }

    void Rotation()
    {
        Camera.transform.Rotate(Vector3.up * rotateSpeed);
    }
}
