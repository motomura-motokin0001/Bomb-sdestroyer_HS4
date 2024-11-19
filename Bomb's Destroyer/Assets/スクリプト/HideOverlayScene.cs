using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HideOverlayScene : MonoBehaviour
{
    public string overlaySceneName;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
        DataManager.Instance.canMove = true;
        DataManager.Instance.canJump = true;
        DataManager.Instance.canLook = true;
        SceneManager.UnloadSceneAsync(overlaySceneName);
        }
    }
}


