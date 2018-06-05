using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficult
{
    Easy,
    Normal,
    Hard,
}

/// <summary>
/// 중재자를 통해 스테이지 시작 요청 받으면 코루틴 시작
/// 코루틴 내부에서 스테이지에 맞게 적 생성
/// List를 통해 에너미 관리
/// </summary>

public class StageManager : Singleton<StageManager> {

    protected StageManager()
    {
        CurrentStage = 0;
    }

    Difficult difficult;
    List<Enemy> EnemyList;
    GameMediator gameMediator;
    const int MaxStage = 3;
    int CurrentStage;

    [SerializeField]
    EnemyFactory Factory;

    private void Start()
    {
        //gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        CurrentStage = 0;
    }
    public void Spawn(Enemy enemy)
    {
        if(enemy.tag == "Enemy")
        {
            Enemy SpwanEnemy = Factory.CreateEnemy(enemy);
            EnemyList.Add(SpwanEnemy);
            Debug.Log("Enemy Spawn 완료");
        }
        else Debug.Log("Spawn() 메서드의 tag 불일치!");
    }

    public void RemoveAllEnemy()
    {
        foreach (Enemy item in EnemyList)
        {
            Destroy(item.gameObject);
        }
        EnemyList.Clear();
        Debug.Log("RemoveAllEnemy 완료");
    }

    public void RemoveEnemy(Enemy enemy)
    {
        Debug.Log("Enemy remove");
        if (enemy.tag == "Enemy")
        {
            EnemyList.Remove(enemy);
            Destroy(enemy.gameObject);
        }
        else Debug.Log("RemoveEnemy 메서드의 tag 불일치!");
    }

    public void NextStage()
    {
        if (CurrentStage == 0)
        {
            StartCoroutine(StageCoroutine(CurrentStage));
            CurrentStage++;
        }
        else if (CurrentStage <= MaxStage)
        {
            StopCoroutine(StageCoroutine(CurrentStage));
            StartCoroutine(StageCoroutine(CurrentStage++));
        }
        else
        {
            Debug.Log("다음 스테이지 없음");
        }
    }

    public void SetDifficulty(Difficult difficult)
    {
        this.difficult = difficult;
        Debug.Log("Set Difficulty : " + difficult);
    }

    public Difficult GetDifficulty()
    {
        Debug.Log("Get Difficulty : " + difficult);
        return difficult;
    }

    //실질석인 스테이지 타임라인
    IEnumerator StageCoroutine(int stageLevel)
    {
        //에너미 쪽 완성 이후 매꿀것
        Debug.Log("스테이지 " + stageLevel + " 시작");
        yield break;
    }
} 
