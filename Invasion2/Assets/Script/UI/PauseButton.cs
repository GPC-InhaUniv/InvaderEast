using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    //void Update()
    //{
    //    OnClickPauseButton();
    //}

    public void OnClickPauseButton()
    {
            Time.timeScale = 0;
            Debug.Log("일시정지 버튼 클릭");
    }
}
