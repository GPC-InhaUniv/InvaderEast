using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 에너미를 생성하는 팩토리
/// CreateEnemy(Enemy EnemyPrefab)
/// </summary>
public class EnemyFactory : MonoBehaviour
{
    public Enemy CreateEnemy(Enemy EnemyPrefab, Transform transform)
    {
        Debug.Log("call CreateEnemy");
        return Instantiate(EnemyPrefab, transform);
    }
}
