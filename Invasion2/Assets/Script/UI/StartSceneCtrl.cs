﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 시작 화면(Scene)을 컨트롤 하기 위한 class
/// mediator를 단 한번만 생성함
/// 이후 mediator가 각 싱글톤 생성
/// </summary>
public class StartSceneCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject HelpPanel;
    [SerializeField]
    GameObject RankPanel;
    [SerializeField]
    GameMediator gameMediatorPrefab;
    public InputManager inputManager;
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        if (GameObject.FindGameObjectWithTag("GameMediator") == null)
        {
            gameMediatorPrefab = Instantiate(gameMediatorPrefab);
            Debug.Log("gameMediator 생성 성공");
        }
        else Debug.Log("gameMediator가 이미 존재함");
    }


    private void EquipManager()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    
    public void OnClickGameStart()
    {
        try
        {
            //메디에이터에 다음 씬 넘기기 요청
            inputManager.ChangeScene(SceneState.CharacterSelect);
        }
        catch
        {
            EquipManager();
        }

    }

    public void OnClickHelp()
    {
        HelpPanel.SetActive(true);
        RankPanel.SetActive(false);
    }

    public void OnClickRank()
    {
        RankPanel.SetActive(true);
        HelpPanel.SetActive(false);
    }

    public void OnClickExit()
    {
        //메디에이터에 게임 종료 요청
        try
        {
            //메디에이터에 다음 씬 넘기기 요청
            inputManager.ChangeScene(SceneState.End);
        }
        catch
        {
            EquipManager();
        }
    }

    public void OnClickByCloseHelpPanel()
    {
        HelpPanel.SetActive(false);
    }

    public void OnClickByCloseRankPanel()
    {
        RankPanel.SetActive(false);
    }
}
