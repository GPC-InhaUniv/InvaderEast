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

    const int MaxStage = 3;

    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }
    public void Spawn(Enemy enemy)
    {
        Debug.Log("Enemy Spawn");
        Enemy SpwanEnemy =  Factory.CreateEnemy(enemy);
        EnemyList.Add(SpwanEnemy);
    }

    public void NextStage()
    {
        if(CurrentStage < MaxStage)
        {
            Debug.Log("Call NextStage");
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
