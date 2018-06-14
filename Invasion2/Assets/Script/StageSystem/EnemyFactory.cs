using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 최대원
/// 에너미를 생성하는 팩토리
/// PoolManager와 연동해야 함
/// </summary>
public class EnemyFactory : MonoBehaviour
{
    public Enemy CreateEnemy(Enemy EnemyPrefab, Transform transform)
    {
        //PoolManager 완성 이후 스크립트 변경 요망
        return Instantiate(EnemyPrefab, transform);
    }
}
