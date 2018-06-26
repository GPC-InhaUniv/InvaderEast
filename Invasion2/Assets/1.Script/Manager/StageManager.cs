using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 난이도 설정
/// </summary>
public enum Difficult
{
    Easy,
    Normal,
    Hard,
}
/// <summary>
/// 재시작을 위한 델리게이트
/// </summary>


/// <summary>
/// 담당자 : 최대원
/// 메디에이터를 통해 스테이지 시작 요청 받으면 코루틴 시작, 
/// 코루틴 내부에서 스테이지에 맞게 적 생성, 
/// List를 통해 에너미 관리
/// </summary>

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    List<GameObject> EnemyList;
    [SerializeField]
    GameObject[] TransformList;
    [SerializeField]
    EnemyFactory Factory;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    BoxCollider Boundary;

   
    CoroutineCtrl stageCoroutineCtrl;

    const int MaxStage = 5;
    int CurrentStage;
    Difficult difficult;
    int transformNumber;

    //스테이지 패턴 발생 간격
    float callCoroutineTick = 5f;

    protected StageManager()
    {
        CurrentStage = 0;
    }

    private void Start()
    {    
        enemyPrefab = Resources.Load("Enemy") as GameObject;
        EnemyList = new List<GameObject>();
        CurrentStage = 0;
        stageCoroutineCtrl = new CoroutineCtrl(this, enemyPrefab);
        Factory = new EnemyFactory();
        GameMediator.Instance.DoGameOver += new GameMediator.DoGameOverDelegate(GameOver);
      
    }

    public void SetStage()
    {
        Debug.Log("SetStage");
        TransformList = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
    }

    public void Spawn(GameObject enemy)
    {
        transformNumber = Random.Range(0, TransformList.Length - 1);
        GameObject SpawnEnemy = Factory.CreateEnemy();
        SpawnEnemy.transform.position = TransformList[transformNumber].transform.position;
        EnemyList.Add(SpawnEnemy);
    }

    public void RemoveAllEnemy()
    {
        foreach (GameObject item in EnemyList)
        {
            GameMediator.Instance.PutEnemyObject(item.gameObject);
        }
        EnemyList.Clear();
        Debug.Log("RemoveAllEnemy 완료");
    }

    public void RemoveEnemy(GameObject enemy)
    { 
        EnemyList.Remove(enemy);
        GameMediator.Instance.PutEnemyObject(enemy);
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
            StartCoroutine(StageCoroutine(CurrentStage));
        }
    }

    //실질석인 스테이지 타임라인
    IEnumerator StageCoroutine(int stageLevel)
    {
        Debug.Log("스테이지 " + stageLevel + " 시작");
        yield return new WaitForSeconds(callCoroutineTick);

        StartCoroutine(stageCoroutineCtrl.StagePattern1(stageLevel));
        yield return new WaitForSeconds(callCoroutineTick);

        StartCoroutine(stageCoroutineCtrl.StagePattern2(stageLevel));
        yield return new WaitForSeconds(callCoroutineTick * 3);

        StartCoroutine(stageCoroutineCtrl.StagePattern3(stageLevel));
        yield return new WaitForSeconds(callCoroutineTick * 2);

        StartCoroutine(stageCoroutineCtrl.StagePattern4(stageLevel));
        yield return new WaitForSeconds(callCoroutineTick);

        StartCoroutine(stageCoroutineCtrl.StagePattern1(stageLevel));
        yield return new WaitForSeconds(callCoroutineTick);

        StartCoroutine(stageCoroutineCtrl.StagePattern4(stageLevel));
        yield return new WaitForSeconds(callCoroutineTick);

        StartCoroutine(stageCoroutineCtrl.StagePattern2(stageLevel));
        yield return new WaitForSeconds(callCoroutineTick * 3);

        StartCoroutine(stageCoroutineCtrl.StagePattern1(stageLevel));
        StartCoroutine(stageCoroutineCtrl.StagePattern1(stageLevel));
        yield return new WaitForSeconds(callCoroutineTick);

        StartCoroutine(stageCoroutineCtrl.StagePattern2(stageLevel));
        StartCoroutine(stageCoroutineCtrl.StagePattern3(stageLevel));

        NextStage();
    }

    private void GameOver()
    {
        StopCoroutine(stageCoroutineCtrl.StagePattern1(CurrentStage));
        StopCoroutine(stageCoroutineCtrl.StagePattern2(CurrentStage));
        StopCoroutine(stageCoroutineCtrl.StagePattern3(CurrentStage));
        StopCoroutine(stageCoroutineCtrl.StagePattern4(CurrentStage));
        CurrentStage = 0;
        StopAllCoroutines();
    }

} 
