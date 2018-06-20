using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 최대원
/// 에너미를 생성하는 팩토리
/// PoolManager와 연동해야 함
/// </summary>
public class EnemyFactory
{
    GameMediator gameMediator;

    public EnemyFactory(GameMediator gameMediator)
    {
        this.gameMediator = gameMediator;
    }

    public GameObject CreateEnemy(Vector3 position)
    {
        GameObject enemy = gameMediator.GetEnemyObject();
        enemy.transform.Translate(position);
        return enemy;
    }
}
