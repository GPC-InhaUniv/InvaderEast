using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    //void Update()
    //{
    //    OnClickRestartButton();
    //}

    public void OnClickRestartButton()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
