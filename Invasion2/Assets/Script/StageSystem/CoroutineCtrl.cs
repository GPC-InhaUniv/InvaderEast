using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCtrl
{
    Enemy enemy;
    StageManager stageManager;

    public CoroutineCtrl(StageManager stageManager, Enemy enemy)
    {
        this.stageManager = stageManager;
        this.enemy = enemy;
    }

    //패턴 1 필드값
    const int pattern1EnemyCount = 5;
    const float pattern1EnemySpawnTick = 0.3f;

    //등장 패턴 1
    public IEnumerator StagePattern1()
    {
        Debug.Log("등장패턴 1 시작");
        for (int i = 0; i < pattern1EnemyCount; i++)
        {
            stageManager.Spawn(enemy);
            yield return new WaitForSeconds(pattern1EnemySpawnTick);
        }
        Debug.Log("등장패턴 1 종료");
        yield break;
    }

    //패턴 2 필드값
    const int pattern2EnemyCount = 5;
    const float pattern2EnemySpawnTick = 0.15f;
    const int pattern2RepeatCount = 3;
    const float pattern2RepeatTick = 2f;

    //등장 패턴 2
    public IEnumerator StagePattern2()
    {
        Debug.Log("등장패턴 2 시작");
        for (int i = 0; i < pattern2RepeatCount; i++)
        {
            for (int j = 0; j < pattern2EnemyCount; j++)
            {
                stageManager.Spawn(enemy);
                yield return new WaitForSeconds(pattern2EnemySpawnTick);
            }
            yield return new WaitForSeconds(pattern2RepeatTick);
        }
        Debug.Log("등장패턴 2 종료");
        yield break;
    }

    //패턴 3 필드값
    const int pattern3EnemyCount = 20;
    const float pattern3EnemySpawnTick = 0.4f;

    //등장 패턴 3
    public IEnumerator StagePattern3()
    {
        Debug.Log("등장패턴 3 시작");
        for (int i = 0; i < pattern3EnemyCount; i++)
        {
            stageManager.Spawn(enemy);
            stageManager.Spawn(enemy);
            yield return new WaitForSeconds(pattern3EnemySpawnTick);
        }
        Debug.Log("등장패턴 3 종료");
        yield break;
    }
}
