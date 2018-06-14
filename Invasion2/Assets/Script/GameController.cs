﻿using UnityEngine;

/// <summary>
/// 담장자 : 김정수
/// 
/// 메인 게임 시작시 필요한 정보들의 관리
/// Ex) 플레이어 시작 위치, 스테이지 시작, 배경관리 등
/// </summary>

public class GameController : MonoBehaviour {

    GameMediator gameMediator;
	// Use this for initialization
	void Start () {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        gameMediator.SetFactory();
	}
	
	
}