using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUICtrl : MonoBehaviour
{
    public void OnClickPauseButton()
    {
        Time.timeScale = 0;


    }

    public void OnClickRestartButton()
    {
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





}
