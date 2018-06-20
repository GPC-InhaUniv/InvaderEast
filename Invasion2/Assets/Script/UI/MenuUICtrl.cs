<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
=======
﻿
>>>>>>> 1f2640dcf9e6661a75f2d79c196c1c73ce4f3f9c
using UnityEngine;

public class MenuUICtrl : MonoBehaviour
{
<<<<<<< HEAD
    public void OnClickPauseButton()
    {
        Time.timeScale = 0;


=======

    public void OnClickReturnTitle()
    {
        Debug.Log("타이틀 화면 클릭");
        InputManager.Instance.ChangeScene(SceneState.Title);
      // SceneManager.LoadScene("Title");
>>>>>>> 1f2640dcf9e6661a75f2d79c196c1c73ce4f3f9c
    }

    public void OnClickRestartButton()
    {
<<<<<<< HEAD
        InputManager.Instance.ChangeScene(SceneState.Battle);
    }

    public void OnClickReturnToTitleButton()
    {
        InputManager.Instance.ChangeScene(SceneState.Title);
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
    }





=======
        Debug.Log("재시작 버튼 클릭");
        InputManager.Instance.ChangeScene(SceneState.Battle);
      // SceneManager.LoadScene("MainGame");
    }

    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        Debug.Log("일시정지 버튼 클릭");
    }


>>>>>>> 1f2640dcf9e6661a75f2d79c196c1c73ce4f3f9c
}
