﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 최대원
/// 시작 화면(Scene)을 컨트롤 하기 위한 스크립트
/// mediator를 단 한번만 생성함
/// 이후 mediator가 각 싱글톤(Manager)을 생성한다.
/// </summary>
public class StartSceneCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject HelpPanel;

    public void OnClickGameStart()
    {
        try
        {
            SaveAndLoader.Instance.LoadData();
        }
        catch
        {
            Debug.Log("저장되어있는 데이터가 없으므로 새 저장데이터를생성합니다.");
            GameDataManager.Instance.ChangeGold(100);
            SaveAndLoader.Instance.SaveData();
            SaveAndLoader.Instance.LoadData();
        }

        //메디에이터에 다음 씬 넘기기 요청
        GameMediator.Instance.ChangeScene(SceneState.CharacterSelect);
    }

    public void OnClickHelp()
    {
        HelpPanel.SetActive(true);
    }

    public void OnClickExit()
    {
        GameMediator.Instance.ChangeScene(SceneState.End);
    }

    public void OnClickByCloseHelpPanel()
    {
        HelpPanel.SetActive(false);
    }
}
