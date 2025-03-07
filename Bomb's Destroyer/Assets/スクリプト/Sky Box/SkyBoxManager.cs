using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{
    [Range(0.001f,1.0f)]
    public float rotateSpeed;
    public Material[] Sky_Box_List;
    int num = 0;
    public Camera Camera;
    void Update ()
    {
        Cursor.lockState = CursorLockMode.None;
        Rotation();
        Change();
    }

    void Change()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            num += 1;
        }

        if(num >= Sky_Box_List.Length)
        {
            num = 0;
        }

        RenderSettings.skybox = Sky_Box_List[num];
    }

    void Rotation()
    {
        Camera.transform.Rotate(Vector3.up * rotateSpeed);

    }
}
