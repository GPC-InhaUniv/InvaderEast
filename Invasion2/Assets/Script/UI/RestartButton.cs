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
            Debug.Log("재시작 버튼 클릭");
            SceneManager.LoadScene("MainGame");
    }
}
