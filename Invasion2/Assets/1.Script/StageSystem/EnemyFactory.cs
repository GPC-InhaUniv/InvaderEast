using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 최대원
/// 에너미를 생성하는 팩토리
/// </summary>
public class EnemyFactory
{
    public GameObject CreateEnemy()
    {
        GameObject enemy = PoolManager.Instance.GetEnemyObject();
        return enemy;
    }
}
