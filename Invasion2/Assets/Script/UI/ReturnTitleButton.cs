using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ReturnTitleButton : MonoBehaviour
{
    //void Update()
    //{
    //    OnClickReturnTitle();
    //}

    public void OnClickReturnTitle()
    {
            Debug.Log("타이틀 화면 클릭");
            SceneManager.LoadScene("Title");
    }
}
