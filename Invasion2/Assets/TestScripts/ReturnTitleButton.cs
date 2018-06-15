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
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
