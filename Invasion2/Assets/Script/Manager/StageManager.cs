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
/// List에서 에너미 관리
/// </summary>

public class StageManager : Singleton<StageManager> {

    protected StageManager()
    {
        CurrentStage = 0;
    }

    public Difficult difficult;
    public int CurrentStage;
    public List<Enemy> EnemyList;
    public EnemyFactory Factory;
    GameMediator gameMediator;

    public Enemy enemy;

    const int MaxStage = 3;

    private void Start()
    {
        //gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        CurrentStage = 0;
    }
    public void Spawn(Enemy enemy)
    {
        if(enemy.tag == "Enemy")
        {
            Debug.Log("Enemy Spawn");
            Enemy SpwanEnemy = Factory.CreateEnemy(enemy);
            EnemyList.Add(SpwanEnemy);
        }
    }

    public void RemoveAllEnemy()
    {
        foreach (Enemy item in EnemyList)
        {
            Destroy(item.gameObject);
        }
        EnemyList.Clear();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        Debug.Log("Enemy remove");
        if (enemy.tag == "Enemy")
        {
           
            EnemyList.Remove(enemy);
            Destroy(enemy.gameObject);
        } 
    }

    public void NextStage()
    {
        if(CurrentStage < MaxStage)
        {
            Debug.Log("Call NextStage : " + CurrentStage);
            StopCoroutine(StageCoroutine(CurrentStage));
            StartCoroutine(StageCoroutine(CurrentStage++));
        }
    }

    public void SetDifficulty(Difficult difficult)
    {
        Debug.Log("Set Difficulty");
        this.difficult = difficult;
    }

    public Difficult GetDifficulty()
    {
        Debug.Log("Get Difficulty");
        return difficult;
    }

    IEnumerator StageCoroutine(int stageLevel)
    {
        Debug.Log("Call StageCoroutine");
        yield break;
    }
}
