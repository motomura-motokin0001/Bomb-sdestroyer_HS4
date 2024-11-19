using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowOverlayScene : MonoBehaviour
{
    public string overlaySceneName;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
        DataManager.Instance.canMove = false;
        DataManager.Instance.canJump = false;
        DataManager.Instance.canLook = false;
        SceneManager.LoadScene(overlaySceneName, LoadSceneMode.Additive);
        }
    }
}
